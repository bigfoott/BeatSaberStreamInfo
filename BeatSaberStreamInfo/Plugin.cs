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
        BeatmapData bmdata;
        BeatmapObjectSpawnController spawncontroller;

        private readonly string dir = Path.Combine(Environment.CurrentDirectory, "UserData/StreamInfo");

        string lastDuration;

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }
        
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
            //bmdata = Resources.FindObjectsOfTypeAll<BeatmapData>().FirstOrDefault();
            spawncontroller = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().FirstOrDefault();
            
            var score = UnityEngine.Object.FindObjectOfType<ScoreController>();
            if (score != null)
            {
                score.comboDidChangeEvent += OnComboChange;
                score.multiplierDidChangeEvent += OnMultiplierChange;
                score.noteWasMissedEvent += OnNoteMiss;

                File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0");
                File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x");
            }

        }


        public void OnComboChange(int c)
        {
            File.WriteAllText(Path.Combine(dir, "Combo.txt"), "" + c);
        }

        public void OnMultiplierChange(int c, float f)
        {
            File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), c + "x");
        }

        public void OnNoteMiss(NoteData data, int c)
        {
            File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0");
            File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x");
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnLevelWasInitialized(int level)
        {
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

                File.WriteAllText(Path.Combine(dir, "Combo.txt"), "0");
                File.WriteAllText(Path.Combine(dir, "Multiplier.txt"), "1x");
            }

        }

        public void OnFixedUpdate()
        {
        }
    }
}
