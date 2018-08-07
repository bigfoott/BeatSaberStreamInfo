using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using IllusionPlugin;
using System.IO;

namespace BeatSaberStreamInfo
{
    public class Plugin : IPlugin
    {
        public string Name => "Beat Saber Stream Info";
        public string Version => "1.0";

        AudioTimeSyncController ats;
        BeatmapDataModel bmdata;

        private readonly string dir = Path.Combine(Environment.CurrentDirectory, "UserData/StreamInfo");

        Dictionary<string, string> template;

        string lastDuration;
        int combo;
        int multiplier;
        int notes_hit;
        int notes_total;
        int score;

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

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
                File.WriteAllText(Path.Combine(dir, "Templates.txt"), "Combo=%combo%\nMultiplier=%multiplier%x\nNotes=%hit%/%total% (%percent%)\nProgress=%current%/%total% (%percent%)\nScore=%score%\nSongName=\"%name%\" by %sub% - %authorname%");

            List<string> sections = new List<string>{ "Combo=", "Multiplier=", "Notes=", "Progress=", "Score=", "SongName=" };
            foreach (string l in File.ReadAllLines(Path.Combine(dir, "Templates.txt")))
            {
                foreach (string sec in sections)
                {
                    if (l.StartsWith(sec))
                    {
                        template.Add(sec.Substring(0, sec.Length - 1), l.Substring(sec.Length - 1));

                        sections.Remove(sec);
                        break;
                    }
                }
            }
            foreach (string s in sections)
                if (!template.ContainsKey(s.Substring(0, s.Length - 1)))
                    template.Add(s.Substring(0, s.Length - 1), "");
        }
        
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == 5)
            {
                ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
                var score = UnityEngine.Object.FindObjectOfType<ScoreController>();
                var setupData = Resources.FindObjectsOfTypeAll<MainGameSceneSetupData>().FirstOrDefault();

                if (setupData != null)
                {
                    var level = setupData.difficultyLevel.level;

                    string songname = template["SongName"];
                    if (songname != "")
                        songname = songname
                            .Replace("%name%", level.songName)
                            .Replace("%sub%", level.songSubName)
                            .Replace("%author%", level.songAuthorName);
                    
                    File.WriteAllText(Path.Combine(dir, "SongName.txt"), songname + "          ");
                }
                if (ats != null)
                {
                    string output = template["Progress"];
                    if (output != "")
                    {
                        string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                        output
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

                combo = 0;
                multiplier = 1;
                notes_hit = 0;
                notes_total = 0;
                this.score = 0;
                multiplier = 1;
                
                if (template["Combo"] != "")
                    File.WriteAllText(Path.Combine(dir, "Combo.txt"), template["Combo"].Replace("%combo%", "0")); // 
                if (template["Multiplier"] != "")
                    File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), template["Multiplier"].Replace("%multiplier%", "1")); //
                if (template["Score"] != "")
                    File.WriteAllText(Path.Combine(dir, "Score.txt"), template["Score"].Replace("%score%", "0")); //
                if (template["Notes"] != "")
                    File.WriteAllText(Path.Combine(dir, "Notes.txt"), template["Notes"].Replace("%hit%", "0").Replace("%total%", "0").Replace("%percent%", "0%")); //
            }
        }
         
        private void OnComboChange(int c)
        {
            combo = c;
        }

        private void OnMultiplierChange(int c, float f)
        {
            multiplier = c;
        }

        private void OnNoteMiss(NoteData data, int c)
        {
            combo = 0;
            multiplier = 1;
            notes_total++;
        }

        private void OnNoteCut(NoteData data, NoteCutInfo nci, int c)
        {
            if (nci.allIsOK)
            {
                notes_hit++;
                notes_total++;
            }
            else if (!nci.allIsOK)
                OnNoteMiss(data, c);
        }
        
        private void OnScoreChange(int c)
        {
            score = c;
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }
         
        public void OnUpdate()
        {
            if (ats != null)
            {
                string time = Math.Floor(ats.songTime / 60).ToString("N0") + ":" + Math.Floor(ats.songTime % 60).ToString("00");
                
                if (lastDuration != time)
                {
                    lastDuration = time;

                    if (template["Combo"] != "")
                        File.WriteAllText(Path.Combine(dir, "Combo.txt"), template["Combo"].Replace("%combo%", "" + combo)); // 
                    if (template["Multiplier"] != "")
                        File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), template["Multiplier"].Replace("%multiplier%", "" + multiplier)); //
                    if (template["Notes"] != "")
                        File.WriteAllText(Path.Combine(dir, "Notes.txt"), template["Notes"].Replace("%hit%", "" + notes_hit).Replace("%total%", "" + notes_total).Replace("%percent%", ((notes_hit * 100 / notes_total)).ToString("N0") + "%")); //
                    if (template["Score"] != "")
                        File.WriteAllText(Path.Combine(dir, "Score.txt"), template["Score"].Replace("%score%", "" + score)); //
                    if (template["Progress"] != "")
                    {
                        string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                        string percent = ((ats.songTime / ats.songLength) * 100).ToString("N0") + "%";

                        File.WriteAllText(Path.Combine(dir, "Progress.txt"), template["Progress"].Replace("%current%", time).Replace("%total%", totaltime).Replace("%percent%", percent)); //
                    }
                }
            }
            else if (lastDuration != "")
                lastDuration = "";
        }

        public void OnFixedUpdate() { }
        public void OnLevelWasLoaded(int level) { }
        public void OnLevelWasInitialized(int level) { }
        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) { }
    }
}
