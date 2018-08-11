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

        // Used to get info about song time and total duration.
        private AudioTimeSyncController ats;

        // The directory where all plugin-related files are read from.
        private readonly string dir = Path.Combine(Environment.CurrentDirectory, "UserData/StreamInfo");

        // List of string templates.
        private Dictionary<string, string> template;

        // Bool to tell if in song or not;
        private bool InSong;

        // Object to store all values about the song.
        private SongInfo info;

        //New thread to write to files from.
        HMTask writer;

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            //Initialize SongInfo;
            info = new SongInfo();

            //Initialize HMTask for writing to files.
            Action job = delegate
            {
                while (InSong)
                {
                    if (InSong)
                    {
                        if (template["Combo"] != "")
                        {
                            File.WriteAllText(Path.Combine(dir, "Combo.txt"), template["Combo"].Replace("%combo%", "" + info.combo)); //
                            Thread.Sleep(150);
                        }
                        if (template["Multiplier"] != "")
                        {
                            File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), template["Multiplier"].Replace("%multiplier%", "" + info.multiplier)); //
                            Thread.Sleep(150);
                        }
                        if (template["Notes"] != "")
                        {
                            if (info.notes_total != 0)
                                File.WriteAllText(Path.Combine(dir, "Notes.txt"), template["Notes"].Replace("%hit%", "" + info.notes_hit).Replace("%total%", "" + info.notes_total).Replace("%percent%", ((info.notes_hit * 100 / info.notes_total)).ToString("N0") + "%")); //
                            Thread.Sleep(150);
                        }
                        if (template["Score"] != "")
                        {
                            File.WriteAllText(Path.Combine(dir, "Score.txt"), template["Score"].Replace("%score%", "" + info.score)); //
                            Thread.Sleep(150);
                        }
                        if (template["Progress"] != "")
                        {
                            string time = Math.Floor(ats.songTime / 60).ToString("N0") + ":" + Math.Floor(ats.songTime % 60).ToString("00");
                            string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                            string percent = ((ats.songTime / ats.songLength) * 100).ToString("N0") + "%";

                            File.WriteAllText(Path.Combine(dir, "Progress.txt"), template["Progress"].Replace("%current%", time).Replace("%total%", totaltime).Replace("%percent%", percent)); //

                            Thread.Sleep(150);
                        }
                    }
                    Thread.Sleep(1000);
                }
            };
            writer = new HMTask(job);

            // Check if files and directories exist, and if not, create them with default values.
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "UserData")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "UserData"));
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!File.Exists(Path.Combine(dir, "Combo.txt")))
                File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0");
            if (!File.Exists(Path.Combine(dir, "Multiplier.txt")))
                File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x");
            if (!File.Exists(Path.Combine(dir, "Notes.txt")))
                File.WriteAllText(Path.Combine(dir, "Notes.txt"), "0/0 (0%)");
            if (!File.Exists(Path.Combine(dir, "Progress.txt")))
                File.WriteAllText(Path.Combine(dir, "Progress.txt"), "");
            if (!File.Exists(Path.Combine(dir, "Score.txt")))
                File.WriteAllText(Path.Combine(dir, "Score.txt"), "0");
            if (!File.Exists(Path.Combine(dir, "SongName.txt")))
                File.WriteAllText(Path.Combine(dir, "SongName.txt"), "");
            if (!File.Exists(Path.Combine(dir, "Templates.txt")))
                File.WriteAllText(Path.Combine(dir, "Templates.txt"), "Combo=%combo%" + Environment.NewLine + "Multiplier=%multiplier%x" + Environment.NewLine + "Notes=%hit%/%total% (%percent%)" + Environment.NewLine + "Progress=%current%/%total% (%percent%)" + Environment.NewLine + "Score=%score%" + Environment.NewLine + "SongName=\"%name%\" by %sub% - %author%");
            
            // Fill template variable with values from text file.
            template = new Dictionary<string, string>();
            List<string> sections = new List<string>{ "Combo", "Multiplier", "Notes", "Progress", "Score", "SongName" };
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
            // If value doesnt exist in file, add KVP with empty string as value.
            foreach (string s in sections)
                if (!template.ContainsKey(s))
                    template.Add(s, "");

            // Set to empty values on game start.
            if (template["Combo"] != "")
                File.WriteAllText(Path.Combine(dir, "Combo.txt"), template["Combo"].Replace("%combo%", "0"));
            if (template["Multiplier"] != "")
                File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), template["Multiplier"].Replace("%multiplier%", "1"));
            if (template["Score"] != "")
                File.WriteAllText(Path.Combine(dir, "Score.txt"), template["Score"].Replace("%score%", "0"));
            if (template["Notes"] != "")
                File.WriteAllText(Path.Combine(dir, "Notes.txt"), template["Notes"].Replace("%hit%", "0").Replace("%total%", "0").Replace("%percent%", "0%"));
            if (template["SongName"] != "")
                File.WriteAllText(Path.Combine(dir, "SongName.txt"), "");
            if (template["Progress"] != "")
            {
                string output = template["Progress"]
                    .Replace("%current%", "0:00")
                    .Replace("%total%", "0:00")
                    .Replace("%percent%", "0%");
                File.WriteAllText(Path.Combine(dir, "Progress.txt"), output);
            }
        }
        
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == 5)
            {
                InSong = true;
                writer.Run();

                // Get objects from scene to pull song data from.
                ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
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
                    // Hook events.
                    score.comboDidChangeEvent += OnComboChange;
                    score.multiplierDidChangeEvent += OnMultiplierChange;
                    score.noteWasMissedEvent += OnNoteMiss;
                    score.noteWasCutEvent += OnNoteCut;
                    score.scoreDidChangeEvent += OnScoreChange;
                }

                // Set variables to default values for start of song.
                info.SetDefault();

                // If template exists, write to file with default values.
                if (template["Combo"] != "")
                    File.WriteAllText(Path.Combine(dir, "Combo.txt"), template["Combo"].Replace("%combo%", "" + info.combo));
                if (template["Multiplier"] != "")
                    File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), template["Multiplier"].Replace("%multiplier%", info.multiplier + "x"));
                if (template["Score"] != "")
                    File.WriteAllText(Path.Combine(dir, "Score.txt"), template["Score"].Replace("%score%", "" + info.score));
                if (template["Notes"] != "")
                    File.WriteAllText(Path.Combine(dir, "Notes.txt"), template["Notes"].Replace("%hit%", "" + info.notes_hit).Replace("%total%", "" + info.notes_total).Replace("%percent%", "0%"));
            }
            else
            {
                InSong = false;
                writer.Cancel();
            }
        }
         
        // Fired when combo changes (not on miss).
        private void OnComboChange(int c)
        {
            info.combo = c;
        }

        // Fired when multiplier changes (not on miss)
        private void OnMultiplierChange(int c, float f)
        {
            info.multiplier = c;
        }

        // Fired when note is missed.
        private void OnNoteMiss(NoteData data, int c)
        {
            // Change combo and multiplier back to default values.
            info.combo = 0;
            info.multiplier = 1;
            info.notes_total++;
        }

        // Fired when note is cut.
        private void OnNoteCut(NoteData data, NoteCutInfo nci, int c)
        {
            // Good cut
            if (nci.allIsOK)
            {
                info.notes_hit++;
                info.notes_total++;
            }
            // Bad cut (miss)
            else
                OnNoteMiss(data, c);
        }
        
        // Fired when the score changes.
        private void OnScoreChange(int c)
        {
            info.score = c;
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
