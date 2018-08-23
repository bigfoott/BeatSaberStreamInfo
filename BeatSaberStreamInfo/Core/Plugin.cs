using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IllusionPlugin;
using IllusionInjector;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BeatSaberStreamInfo
{
    public class Plugin : IPlugin
    {
        public string Name => "Beat Saber Stream Info";
        public string Version => "1.0";

        private AudioTimeSyncController ats;
        private GameEnergyCounter energy;
        public static readonly string dir = Path.Combine(Environment.CurrentDirectory, "UserData/StreamInfo");
        private bool InSong;
        private bool EnergyReached0;
        private bool BailOutInstalled;
        private int overlayRefreshRate;
        private SongInfo info;
        Action job;
        Action StartJob;
        HMTask writer;
        HMTask OverlayTask;
        HMTask StartTask;

        Overlay overlay;
        
        string _songName;
        string _songAuthor;
        string _songSub;

        int highestCombo = 0;
        
        bool overlayEnabled = false;

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            BailOutInstalled = PluginManager.Plugins.Any(p => p.Name.Contains("Bail") && p.Name.Contains("Out") && p.Name.Contains("Mode"));
            if (BailOutInstalled)
                Console.WriteLine("[StreamInfo] BailOut plugin found.");
            else
                Console.WriteLine("[StreamInfo] BailOut plugin not found.");
            
            info = new SongInfo();

            InitTasks();

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "UserData")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "UserData"));
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!Directory.Exists(Path.Combine(dir, "data")))
                Directory.CreateDirectory(Path.Combine(dir, "data"));

            foreach (string s in new[] { "SongName", "Config", "OverlayConfig", "data/overlaypos" })
                if (!File.Exists(Path.Combine(dir, s + ".txt")))
                {
                    Console.WriteLine("[StreamInfo] " + s + ".txt not found. Creating file...");
                    if (s == "Config")
                        File.WriteAllText(Path.Combine(dir, s + ".txt"), "OverlayEnabled=True");
                    else if (s == "OverlayConfig")
                        File.WriteAllText(Path.Combine(dir, s + ".txt"), "TextColor=White" + Environment.NewLine + "BackgroundColor=Black" + Environment.NewLine + "UseBackgroundImage=False" + Environment.NewLine + "RefreshRate=100");
                    else if (s == "data/overlaypos")
                        File.WriteAllText(Path.Combine(dir, s + ".txt"), "567,288" + Environment.NewLine + "0,0");
                    else
                        File.WriteAllText(Path.Combine(dir, s + ".txt"), "");
                }
            
            foreach (string l in File.ReadAllLines(Path.Combine(dir, "Config.txt")))
            {
                if (l.ToLower().StartsWith("overlayenabled=true"))
                {
                    Console.WriteLine("[StreamInfo] Launching overlay...");
                    overlay = new Overlay();
                    overlay.FormClosed += Overlay_FormClosed;
                    Action overlayjob = delegate { System.Windows.Forms.Application.Run(overlay); };
                    OverlayTask = new HMTask(overlayjob);
                    OverlayTask.Run();
                    overlay.Refresh();
                    overlayRefreshRate = 100;
                    foreach (string line in File.ReadAllLines(Path.Combine(dir, "OverlayConfig.txt")))
                    {
                        if (line.StartsWith("RefreshRate=") && line.Length > 12)
                        {
                            if (int.TryParse(line.Substring(12), out int result))
                            {
                                if (result < 1)
                                    result = 1;

                                overlayRefreshRate = result; 
                            }
                        }
                    }

                    Console.WriteLine("[StreamInfo] Overlay started.");
                    overlayEnabled = true;
                }
            }
        }
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (overlayEnabled)
            {
                if (arg1.name == "DefaultEnvironment" || arg1.name == "BigMirrorEnvironment" || arg1.name == "TriangleEnvironment" || arg1.name == "NiceEnvironment")
                {
                    StartTask = new HMTask(StartJob);
                    StartTask.Run();
                }
                else if (InSong)
                {
                    Console.WriteLine("[StreamInfo] Exited song scene. Resetting...");
                    
                    InSong = false;
                    writer.Cancel();
                    ats = null;
                    energy = null;
                    File.WriteAllText(Path.Combine(dir, "SongName.txt"), "");

                    Console.WriteLine("[StreamInfo] Done! Ready for next song.");
                }
            }
        }

        private void OnComboChange(int c)
        {
            info.combo = c;
            if (c > highestCombo)
                highestCombo = c;
        }
        private void OnMultiplierChange(int c, float f)
        {
            info.multiplier = c;
        }
        private void OnNoteMiss(NoteData data, int c)
        {
            info.combo = 0;
            info.notes_total++;
        }
        private void OnNoteCut(NoteData data, NoteCutInfo nci, int c)
        {
            if (nci.allIsOK)
            {
                info.notes_hit++;
                info.notes_total++;
            }
            else
                OnNoteMiss(data, c);
        }
        private void OnScoreChange(int c)
        {
            info.score = c;
        }

        private void OnEnergyChange(float f)
        {
            if (!EnergyReached0)
                info.energy = (int)(f * 100);
        }
        private void OnEnergyFail()
        {
            EnergyReached0 = true;
            File.WriteAllText(Path.Combine(dir, "Energy.txt"), "");
        }

        private void Overlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            overlay = null;
            overlayEnabled = false;
        }

        private void ResetBailedOut()
        {
            BailOutModePlugin.BailedOut = false;
        }
        private bool BailedOut()
        {
            return BailOutModePlugin.BailedOut;
        }
        private void InitTasks()
        {
            job = delegate
            {
                Console.WriteLine("[StreamInfo] HMTask started.");
                while (InSong)
                {
                    if (ats != null)
                    {
                        string time = Math.Floor(ats.songTime / 60).ToString("N0") + ":" + Math.Floor(ats.songTime % 60).ToString("00");
                        string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                        string percent = ((ats.songTime / ats.songLength) * 100).ToString("N0");

                        overlay.UpdateText(info.GetVal("multiplier"),
                            info.GetVal("score"),
                            time + " / " + totaltime + " (" + percent + "%)",
                            info.GetVal("combo"),
                            info.GetVal("notes_hit") + "/" + info.GetVal("notes_total") + " (" + info.GetVal("percent") + "%)",
                            info.GetVal("energy"));
                    }
                    Thread.Sleep(overlayRefreshRate);
                }
            };
            writer = new HMTask(job);

            StartJob = delegate
            {
                Console.WriteLine("[StreamInfo] Entered song scene. Initializing...");
                InSong = true;
                EnergyReached0 = false;
                if (BailOutInstalled)
                    ResetBailedOut();
                writer = new HMTask(job);
                writer.Run();
                highestCombo = 0;
                Thread.Sleep(500);

                Console.WriteLine("[StreamInfo] Finding objects...");
                ats = UnityEngine.Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
                energy = UnityEngine.Resources.FindObjectsOfTypeAll<GameEnergyCounter>().FirstOrDefault();
                var score = UnityEngine.Resources.FindObjectsOfTypeAll<ScoreController>().FirstOrDefault();
                var setupData = UnityEngine.Resources.FindObjectsOfTypeAll<MainGameSceneSetupData>().FirstOrDefault();

                string progress = "";

                if (setupData != null)
                {
                    Console.WriteLine("[StreamInfo] Getting song name data...");
                    var level = setupData.difficultyLevel.level;

                    _songName = level.songName;
                    _songSub = level.songSubName;
                    _songAuthor = level.songAuthorName;

                    string songname = "\"" + _songName + "\" by " + _songSub + " - " + _songAuthor;
                    File.WriteAllText(Path.Combine(dir, "SongName.txt"), songname + "               ");
                }
                if (ats != null)
                {
                    progress = "0:00/" + Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00") + " (0%)";
                }
                Console.WriteLine("[StreamInfo] Hooking Events...");
                if (score != null)
                {
                    score.comboDidChangeEvent += OnComboChange;
                    score.multiplierDidChangeEvent += OnMultiplierChange;
                    score.noteWasMissedEvent += OnNoteMiss;
                    score.noteWasCutEvent += OnNoteCut;
                    score.scoreDidChangeEvent += OnScoreChange;
                }
                if (energy != null)
                {
                    energy.gameEnergyDidChangeEvent += OnEnergyChange;
                    if (!BailOutInstalled)
                        energy.gameEnergyDidReach0Event += OnEnergyFail;
                }

                info.SetDefault();

                if (overlayEnabled)
                {
                    Console.WriteLine("[StreamInfo] Updating overlay...");
                    overlay.UpdateText(info.GetVal("multiplier"),
                                info.GetVal("score"),
                                progress,
                                info.GetVal("combo"),
                                info.GetVal("notes_hit") + "/" + info.GetVal("notes_total") + " (" + info.GetVal("percent") + "%)",
                                info.GetVal("energy"));
                }
            };
            StartTask = new HMTask(StartJob);
        }

        public void OnApplicationQuit()
        {
            if (overlayEnabled && overlay != null)
            {
                overlay.ShutDown();
                OverlayTask.Cancel();
            }

            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }
        public void OnUpdate() { }
        public void OnFixedUpdate() { }
        public void OnLevelWasLoaded(int level) { }
        public void OnLevelWasInitialized(int level) { }
        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) { }
    }
}
