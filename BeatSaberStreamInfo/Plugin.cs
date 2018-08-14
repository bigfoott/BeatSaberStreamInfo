using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IllusionPlugin;
using System.IO;
using System.Threading;

namespace BeatSaberStreamInfo
{
    public class Plugin : IPlugin
    {
        public string Name => "Beat Saber Stream Info";
        public string Version => "1.0";

        private AudioTimeSyncController ats;
        private GameEnergyCounter energy;
        private readonly string dir = Path.Combine(Environment.CurrentDirectory, "UserData/StreamInfo");
        private Dictionary<string, string> template;
        private Dictionary<string, Dictionary<string, string>> templateReplace;
        private bool InSong;
        private bool EnergyReached0;
        private SongInfo info;
        Action job;
        HMTask writer;
        
        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            info = new SongInfo();
            templateReplace = new Dictionary<string, Dictionary<string, string>>
                {
                    { "Combo", new Dictionary<string, string> { { "%combo%", "combo" } } },
                    { "Multiplier", new Dictionary<string, string> { { "%multiplier%", "multiplier" } } },
                    { "Notes", new Dictionary<string, string> { { "%hit%", "notes_hit" }, { "%total%", "notes_total" }, { "%percent%", "percent" } } },
                    { "Score", new Dictionary<string, string> { { "%score%", "score" } } }
                };

            job = delegate
            {
                var lastWritten = new Dictionary<string, string>();
                
                while (InSong)
                {
                    // Get specific value and write to file if template exists.
                    Console.WriteLine(1);
                    foreach (KeyValuePair<string, Dictionary<string, string>> kvp in templateReplace)
                    {
                        if (template[kvp.Key] == "")
                            continue;
                        Console.WriteLine(11);
                        string val = template[kvp.Key];
                        foreach (KeyValuePair<string, string> r in kvp.Value)
                            val = val.Replace(r.Key, info.GetVal(r.Value));
                        Console.WriteLine(12);
                        if (!lastWritten.ContainsKey(kvp.Key))
                            lastWritten.Add(kvp.Key, val);
                        else if (lastWritten[kvp.Key] == val)
                            continue;
                        Console.WriteLine(13);
                        File.WriteAllText(Path.Combine(dir, kvp.Key + ".txt"), val); //

                        Thread.Sleep(400);
                    }
                    Console.WriteLine(2);
                    // Essentially the same as above but separate due to other variables being necessary
                    if (template["Progress"] != "")
                    {
                        Console.WriteLine(21);
                        string time = Math.Floor(ats.songTime / 60).ToString("N0") + ":" + Math.Floor(ats.songTime % 60).ToString("00");
                        Console.WriteLine(22);
                        string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                        Console.WriteLine(23);
                        string percent = ((ats.songTime / ats.songLength) * 100).ToString("N0");
                        Console.WriteLine(24);

                        File.WriteAllText(Path.Combine(dir, "Progress.txt"),
                            template["Progress"].Replace("%current%", time)
                            .Replace("%total%", totaltime).Replace("%percent%", percent + "%")); //
                        Thread.Sleep(400);
                    }
                    Console.WriteLine(3);
                    if (!EnergyReached0 && template["Energy"] != "")
                    {
                        string percent = info.GetVal("energy");
                        Console.WriteLine(31);
                        string output = template["Energy"].Replace("%percent%", percent + "%");
                        Console.WriteLine(32);

                        if (output.Contains("%bar%"))
                        {
                            Console.WriteLine(33);
                            string bar = "";
                            int count = Convert.ToInt32(percent) / 5;
                            Console.WriteLine(34);
                            for (int i = 0; i < count; i++)
                                bar += "█";
                            Console.WriteLine(35);
                            for (int i = 0; i < 20 - count; i++)
                                bar += "░";
                            Console.WriteLine(36);
                            output = output.Replace("%bar%", bar);
                        }

                        File.WriteAllText(Path.Combine(dir, "Energy.txt"), output);
                    }
                    Console.WriteLine(4);
                    Thread.Sleep(2000);
                }
            };
            writer = new HMTask(job);

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "UserData")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "UserData"));
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            List<string> sections = new List<string> { "Combo", "Multiplier", "Notes", "Progress", "Score", "SongName", "Energy" };
            foreach (string s in sections)
                if (!File.Exists(Path.Combine(dir, s + ".txt")))
                    File.WriteAllText(Path.Combine(dir, s + ".txt"), "");

            if (!File.Exists(Path.Combine(dir, "Templates.txt")))
                File.WriteAllText(Path.Combine(dir, "Templates.txt"),
                    "Combo=%combo%" + Environment.NewLine +
                    "Multiplier=%multiplier%x" + Environment.NewLine +
                    "Notes=%hit%/%total% (%percent%)" + Environment.NewLine +
                    "Progress=%current%/%total% (%percent%)" + Environment.NewLine +
                    "Score=%score%" + Environment.NewLine +
                    "SongName=\"%name%\" by %sub% - %author%" + Environment.NewLine +
                    "Energy=%bar% (%percent%)"); //█░

            // Fill template variable with values from text file.
            template = new Dictionary<string, string>();
            foreach (string l in File.ReadAllLines(Path.Combine(dir, "Templates.txt")))
            {
                if (l.StartsWith("//"))
                    continue;
                foreach (string sec in sections)
                {
                    if (l.StartsWith(sec + "="))
                    {
                        template.Add(sec, l.Substring(sec.Length + 1).Replace("%nl%", Environment.NewLine));

                        sections.Remove(sec);
                        break;
                    }
                }
            }
            foreach (string s in sections)
                if (!template.ContainsKey(s))
                    template.Add(s, "");

            WriteDefaults();
        }
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == 5)
            {
                InSong = true;
                EnergyReached0 = false;
                writer = new HMTask(job);
                writer.Run();

                // Get objects from scene to pull song data from.
                ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
                energy = Resources.FindObjectsOfTypeAll<GameEnergyCounter>().FirstOrDefault();
                var score = UnityEngine.Object.FindObjectOfType<ScoreController>();
                var setupData = Resources.FindObjectsOfTypeAll<MainGameSceneSetupData>().FirstOrDefault();

                if (setupData != null)
                {
                    var level = setupData.difficultyLevel.level;
                    
                    // Replace template placeholders with song data.
                    string songname = template["SongName"];
                    if (songname != "")
                        songname = songname
                            .Replace("%name%", level.songName)
                            .Replace("%sub%", level.songSubName)
                            .Replace("%author%", level.songAuthorName);

                    File.WriteAllText(Path.Combine(dir, "SongName.txt"), songname + "               ");
                }
                if (ats != null)
                {
                    if (template["Progress"] != "")
                    {
                        // Replace template placeholders with default values and total song time.
                        string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                        string output = template["Progress"]
                            .Replace("%current%", "0:00")
                            .Replace("%total%", totaltime)
                            .Replace("%percent%", "0%");
                        
                        File.WriteAllText(Path.Combine(dir, "Progress.txt"), output);
                    }
                }
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
                    energy.gameEnergyDidReach0Event += OnEnergyFail;

                    if (template["Energy"] != "")
                    {
                        string output = template["Energy"].Replace("%bar%", "██████████░░░░░░░░░░").Replace("%percent%", "50%");
                        File.WriteAllText(Path.Combine(dir, "Energy.txt"), output);
                    }
                }
                
                // Set variables to default values for start of song.
                info.SetDefault();

                // Write default values to text file.
                WriteDefaults();
            }
            else
            {
                InSong = false;
                writer.Cancel();

                ats = null;
                energy = null;
            }
        }
         
        private void OnComboChange(int c)
        {
            info.combo = c;
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
            else // Bad cut (miss)
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
            Console.WriteLine("BEPIS");
            File.WriteAllText(Path.Combine(dir, "Energy.txt"), ""); 
        }

        private void WriteDefaults()
        {   
            if (template["Combo"] != "")
                File.WriteAllText(Path.Combine(dir, "Combo.txt"), template["Combo"].Replace("%combo%", "0"));
            if (template["Multiplier"] != "")
                File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), template["Multiplier"].Replace("%multiplier%", "1"));
            if (template["Score"] != "")
                File.WriteAllText(Path.Combine(dir, "Score.txt"), template["Score"].Replace("%score%", "0"));
            if (template["Notes"] != "")
                File.WriteAllText(Path.Combine(dir, "Notes.txt"), template["Notes"].Replace("%hit%", "0").Replace("%total%", "0").Replace("%percent%", "0%"));
        }
        
        public void OnApplicationQuit()
        {
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
