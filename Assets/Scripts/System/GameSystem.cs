//using MatchThree.Game.GamePlay;
using cfg;
using QFramework;
using Roots;
using Roots.Event;
using Roots.Game;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using Unity.VisualScripting.Dependencies.NCalc;
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
        public Character firstMainCharacter;
        private List<Character> characterList = new List<Character>();
        private float yearLength;
        public Tables Table;

        public List<int> GenUnique = new List<int>();
        public List<int> HistUnique = new List<int>();
        public List<int> HisDoneEvents = new List<int>();
        public Character MainCharacter => mainCharacter;

        protected override void OnInit()
        {
            ResKit.Init();
            _resLoader = ResLoader.Allocate();
            Table = new Tables(Loader);
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
        public Character CreateCharacter(string name, int Age, int MaxAge, bool Sex, Character MainParent = null, Character SubParent = null)
        {
            Character character = new Character(name, Age, MaxAge, Sex, MainParent, SubParent);
            characterList.Add(character);
            return character;
        }

        

        /// <summary>
        /// 创建游戏开始时第一个主角
        /// </summary>
        public Character CreateFirstCharacter()
        {
            int sex = Random.Range(0, 2);
            Character firstCharacter = new Character(NameGenerator.Instance.GenerateName(sex == 0), 18, 80, sex == 0);
            mainCharacter = firstCharacter;
            characterList.Add(firstCharacter);
            firstMainCharacter = firstCharacter;
            return firstMainCharacter;
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
                    characterList[i].IncreaseAge(1);
                }
            }

            if(mainCharacter.CharacterState != CharacterState.Live)
            {
                UIKit.OpenPanel<UIInheritPanel>();
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
            GenUnique.Clear();
            this.SendEvent(new ChooseNewCharacterEvent() { Character = character });
        }


        public bool IsMainCharacter(Character character)
        {
            return mainCharacter == character;
        }
        
        private JSONNode Loader(string fileName)
        {
            return JSON.Parse(
                File.ReadAllText((Application.dataPath + "/../GeneratedDatas/json/" + fileName + ".json")));
        }
    }
}