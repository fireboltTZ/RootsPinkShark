//using MatchThree.Game.GamePlay;
using cfg;
using QFramework;
using Roots;
using Roots.Event;
using Roots.Game;
using UnityEditor;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;


namespace MatchThree.System
{
    //你好
    public class GameSystem : AbstractSystem
    {
        
        private ResLoader _resLoader = ResLoader.Allocate();
        private Character mainCharacter;

        protected override void OnInit()
        {
            _resLoader = ResLoader.Allocate();
        }
        
        
        public void StartGame()
        {
            //Create New Character
            
            //Start New UIPanel
            UIKit.OpenPanel<UIGamePanel>();
            //Character 
        }
        
        //TODO
        public void EndGame()
        {
            //Depends on Character Stat
        }
        
        public void StartBattle()
        {
            //UIKit.OpenPanel<UIBattlePanel>();
        }

        
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}