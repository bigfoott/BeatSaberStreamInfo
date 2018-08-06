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
        }
        
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == 5)
            {
                ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
                bmdata = Resources.FindObjectsOfTypeAll<BeatmapDataModel>().FirstOrDefault();
                var score = UnityEngine.Object.FindObjectOfType<ScoreController>();
                var setupData = Resources.FindObjectsOfTypeAll<MainGameSceneSetupData>().FirstOrDefault();

                if (score != null && bmdata != null && ats != null && setupData != null)
                {
                    score.comboDidChangeEvent += OnComboChange;
                    score.multiplierDidChangeEvent += OnMultiplierChange;
                    score.noteWasMissedEvent += OnNoteMiss;
                    score.noteWasCutEvent += OnNoteCut;
                    score.scoreDidChangeEvent += OnScoreChange;

                    string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                    string output = "0:00/" + totaltime + " (0%)";

                    var level = setupData.difficultyLevel.level;
                    string songname = level.songName;
                    if (level.songSubName != "")
                        songname += " by " + level.songSubName;
                    if (level.songAuthorName != "")
                        songname += " - " + level.songAuthorName;

                    combo = 0;
                    multiplier = 1;
                    notes_hit = 0;
                    notes_total = bmdata.beatmapData.notesCount;
                    this.score = 0;
                    multiplier = 1;

                    File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0"); // 
                    File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x"); //
                    File.WriteAllText(Path.Combine(dir, "Notes.txt"), "0/" + notes_total); //
                    File.WriteAllText(Path.Combine(dir, "Progress.txt"), output);
                    File.WriteAllText(Path.Combine(dir, "Score.txt"), "0"); //
                    File.WriteAllText(Path.Combine(dir, "SongName.txt"), songname + "     ");
                }
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
        }

        private void OnNoteCut(NoteData data, NoteCutInfo nci, int c)
        {
            if (nci.allIsOK)
                notes_hit++;
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
                string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                string percent = ((ats.songTime / ats.songLength) * 100).ToString("N0");
                string output = time + "/" + totaltime + " (" + percent + "%)";
                
                if (lastDuration != output)
                {
                    lastDuration = output;

                    File.WriteAllText(Path.Combine(dir, "Combo.txt"), "" + combo);
                    File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), multiplier + "x");
                    File.WriteAllText(Path.Combine(dir, "Notes.txt"), notes_hit + "/" + notes_total + " (" + ((notes_hit * 100 / notes_total)).ToString("N0") + "%)");
                    File.WriteAllText(Path.Combine(dir, "Score.txt"), "" + score);
                    File.WriteAllText(Path.Combine(dir, "Progress.txt"), output);
                }
            }
            else if (lastDuration != "")
            {
                lastDuration = "";
                //File.WriteAllText(Path.Combine(dir, "Progress.txt"), "");
            }
        }

        public void OnFixedUpdate() { }
        public void OnLevelWasLoaded(int level) { }
        public void OnLevelWasInitialized(int level) { }
        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) { }
    }
}
