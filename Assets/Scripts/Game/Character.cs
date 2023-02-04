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
            Strength = UnityEngine.Random.Range(1, 6);
            Agility = UnityEngine.Random.Range(1, 6);
            Intelligence = 10 - Strength - Agility;
            if (Intelligence < 0)
            {
                Intelligence = 0;
            }


            this.CharacterState = CharacterState.Live;
            this.Birth();
        }

        public void Birth()
        {
            if (MainParent != null)
            {
                MainParent.Children.Add(this);
            }
            if (SubParent != null)
            {
                SubParent.Children.Add(this);
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
            return null;
        }


        public void UseResource(GameResource resource)
        {
            ResourceExecutor.Instance.ResourceEffect(this, resource);
        }


        /// <summary>
        /// »ñµÃTag
        /// </summary>
        /// <param name="tag"></param>
        public void GetTag(GameTag tag)
        {
            if (Tags == null)
            {
                Tags = new List<GameTag>();
            }
            for(int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].TagGroupId == tag.TagGroupId)
                {
                    Tags.Remove(Tags[i]);
                }
            }
            Tags.Add(tag);
        }



        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
    }
}