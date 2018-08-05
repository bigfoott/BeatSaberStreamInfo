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

        private readonly string dir = Environment.CurrentDirectory;

        string lastDuration;

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }
        
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            var score = UnityEngine.Object.FindObjectOfType<ScoreController>();
            if (score != null)
            {
                score.noteWasCutEvent += OnHit; 
            }
            
            ats = Resources.FindObjectsOfTypeAll<AudioTimeSyncController>().FirstOrDefault();
        }

        public void OnHit(NoteData data, NoteCutInfo cut, int h)
        {

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
                
                if (lastDuration == null || lastDuration != output)
                {
                    lastDuration = output;
                    File.WriteAllText(Path.Combine(dir, "SongProgress.txt"), output);
                }
            }
            else
                File.WriteAllText(Path.Combine(dir, "SongProgress.txt"), "");

        }

        public void OnFixedUpdate()
        {
        }
    }
}
