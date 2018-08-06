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
        BeatmapObjectSpawnController spawncontroller;

        private readonly string dir = Path.Combine(Environment.CurrentDirectory, "UserData/StreamInfo");
        string lastDuration;
        int totalhit;

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
        }
        
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == 5)
            {
                ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
                bmdata = Resources.FindObjectsOfTypeAll<BeatmapDataModel>().FirstOrDefault();
                spawncontroller = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().FirstOrDefault();

                var score = UnityEngine.Object.FindObjectOfType<ScoreController>();
                if (score != null)
                {
                    score.comboDidChangeEvent += OnComboChange;
                    score.multiplierDidChangeEvent += OnMultiplierChange;
                    score.noteWasMissedEvent += OnNoteMiss;
                    score.noteWasCutEvent += OnNoteCut;
                    score.scoreDidChangeEvent += OnScoreChange;

                    string totaltime = Math.Floor(ats.songLength / 60).ToString("N0") + ":" + Math.Floor(ats.songLength % 60).ToString("00");
                    string output = "0:00/" + totaltime + " (0%)";

                    File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0");
                    File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x");
                    File.WriteAllText(Path.Combine(dir, "Notes.txt"), "0/" + bmdata.beatmapData.notesCount);
                    File.WriteAllText(Path.Combine(dir, "Progress.txt"), output);
                    File.WriteAllText(Path.Combine(dir, "Score.txt"), "0");
                    totalhit = 0;
                }
            }

        }
         
        private void OnComboChange(int c)
        {
            File.WriteAllText(Path.Combine(dir, "Combo.txt"), "" + c);
        }

        private void OnMultiplierChange(int c, float f)
        {
            File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), c + "x");
        }

        private void OnNoteMiss(NoteData data, int c)
        {
            File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0");
            File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x");
        }

        private void OnNoteCut(NoteData data, NoteCutInfo nci, int c)
        {
            if (bmdata != null && nci.allIsOK)
            {
                totalhit++;
                int total = bmdata.beatmapData.notesCount;
                File.WriteAllText(Path.Combine(dir, "Notes.txt"), totalhit + "/" + total + " (" + ((totalhit / total) * 100).ToString("N0") + "%)");
            }
            else if (!nci.allIsOK)
                OnNoteMiss(data, c);
        }
        
        private void OnScoreChange(int c)
        {
            File.WriteAllText(Path.Combine(dir, "Score.txt"), "" + c);
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
                    File.WriteAllText(Path.Combine(dir, "Progress.txt"), output);
                }
            }
            else if (lastDuration != "")
            {
                lastDuration = "";
                File.WriteAllText(Path.Combine(dir, "Progress.txt"), "");
            }
        }

        public void OnFixedUpdate() { }
        public void OnLevelWasLoaded(int level) { }
        public void OnLevelWasInitialized(int level) { }
        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) { }
    }
}
