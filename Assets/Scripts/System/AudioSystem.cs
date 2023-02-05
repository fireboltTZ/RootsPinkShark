using QFramework;
using UnityEditor;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;


namespace MatchThree.System
{
    //你好
    public class AudioSystem : AbstractSystem
    {
        protected override void OnInit()
        {
            AudioKit.MusicPlayer.SetVolume(PlayerPrefs.GetInt("Music"));
            AudioKit.VoicePlayer.SetVolume(PlayerPrefs.GetInt("Volume"));
        }

        public void PlayMusic(string s)
        {
            AudioKit.PlayMusic(s);
        }
        
        


    }
}