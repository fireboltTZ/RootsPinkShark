//using MatchThree.Game.GamePlay;
using cfg;
using QFramework;
using Roots;
using Roots.Game;
using System.Collections;
using System.Collections.Generic;
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
        private Character firstMainCharacter;
        private List<Character> characterList;
        private float yearLength;

        protected override void OnInit()
        {
            _resLoader = ResLoader.Allocate();
        }
        
        
        public void StartGame()
        {
            //Create New Character
            CreateFirstCharacter();
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


        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Age"></param>
        /// <param name="MaxAge"></param>
        /// <param name="Sex"></param>
        /// <param name="MainParent"></param>
        /// <param name="SubParent"></param>
        public void CreateCharacter(string name, int Age, int MaxAge, bool Sex, Character MainParent = null, Character SubParent = null)
        {
            Character character = new Character(name, Age, MaxAge, Sex, MainParent, SubParent);
            characterList.Add(character);
        }



        /// <summary>
        /// 创建游戏开始时第一个主角
        /// </summary>
        public void CreateFirstCharacter()
        {
            Character firstCharacter = new Character("", 18, 80, true);
            mainCharacter = firstCharacter;
            characterList.Add(firstCharacter);
            firstMainCharacter = firstCharacter;
        }



        /// <summary>
        /// 游戏时间推进，所有角色年龄增长一岁
        /// </summary>
        public void GameTimePass()
        {
            for(int i = 0; i < characterList.Count; i++)
            {
                if (characterList[i].CharacterState != CharacterState.Die)
                {
                    characterList[i].IncreaseAge();
                }
            }

            if(mainCharacter.CharacterState != CharacterState.Live)
            {
                //TODO:打开选择继承人Panel
            }
        }


        /// <summary>
        /// 角色死亡或隐退，触发更换主角
        /// </summary>
        public void ChangeMainCharacter(Character character, List<GameResource> resources, GameTag tag)
        {
            mainCharacter = character;
            character.Resources.AddRange(resources);
            character.GetTag(tag);
        }


        public bool IsMainCharacter(Character character)
        {
            return mainCharacter == character;
        }
    }
}