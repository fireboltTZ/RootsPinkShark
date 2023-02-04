using System;
using System.Collections.Generic;
using cfg;
using MatchThree.System;
using QFramework;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

namespace Roots.Game
{

    public enum CharacterState
    {
        Die, Retired, Live, Children
    }
    public class Character : ICanGetSystem
    {
        #region BasicAttribute

        public string Name;
        public int Age;
        private int MaxAge;
        public bool Sex;
        public CharacterState CharacterState;
        
        #endregion
        
        #region ChooseAttribute

        public int Strength;
        public int Agility;
        public int Intelligence;
        
        #endregion

        #region Staff

        public List<GameResource> Resources;
        public List<GameTag> Tags;

        #endregion

        #region Relationship

        public Character Spouse;
        public Character MainParent;
        public Character SubParent;
        public List<Character> Children;

        #endregion

        public Character(string name, int Age, int MaxAge, bool Sex, Character MainParent = null, Character SubParent = null)
        {
            this.Name= name;
            this.Age = Age;
            this.MaxAge= MaxAge;
            this.Sex = Sex;
            this.MainParent = MainParent;
            this.SubParent = SubParent;
            //TODO:三项属性的随机生成（未知取值范围）


            this.CharacterState = CharacterState.Live;
            this.Birth();
        }

        public void Birth()
        {
            if (MainParent != null)
            {
                MainParent.AddToChildren(this);
            }
            if (SubParent != null)
            {
                SubParent.AddToChildren(this);
            }
        }

        public void Die()
        {
            CharacterState = CharacterState.Die;
        }


        public void Retired()
        {
            CharacterState = CharacterState.Retired;
        }

        public void Marry(Character character)
        {
            Spouse = character;
        }


        public void IncreaseAge()
        {
            Age++;
            if (Age > MaxAge)
            {
                Die();
                return;
            }
            this.GetSystem<GameEventSystem>().DrawEvent(this);
            
        }

//TODO
        private List<Character> GetAllChildren()
        {
            return Children;
        }
        public void UseResource()
        {
            
        }

        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }

        public void AddToChildren(Character character)
        {
            if (Children == null)
            { 
                Children= new List<Character>();
            }
            if (!Children.Contains(character))
            {
                Children.Add(character);
            }
            if(MainParent!= null)
            {
                MainParent.AddToChildren(character);
            }
            if(SubParent!= null)
            {
                SubParent.AddToChildren(character);
            }
        }
    }
}