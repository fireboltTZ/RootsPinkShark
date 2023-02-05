using System;
using System.Collections.Generic;
using cfg;
using MatchThree.System;
using QFramework;
using Roots.Event;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

namespace Roots.Game
{

    public enum CharacterState
    {
        Die, Retired, Live, Children
    }
    public class Character : ICanGetSystem, ICanSendEvent
    {
        #region BasicAttribute

        public string Name;
        public int Age;
        private int MaxAge;
        public bool Sex;
        public CharacterState CharacterState;

        #endregion

        #region ChooseAttribute

        public int LINGLI;
        public int SHENSHI;
        public int BOWEN;
        public int XINGYUN;

        public Dictionary<int, int> TempAttr = new Dictionary<int, int>();

        #endregion

        #region Staff

        public List<GameResource> Resources;
        public List<GameTag> Tags;

        public BindableProperty<int> AgeBind = new BindableProperty<int>();
        #endregion

        #region Relationship

        public Character Spouse;
        public Character MainParent;
        public Character SubParent;
        public List<Character> Children = new List<Character>();

        public List<int> DoneEvents = new List<int>(); 

        #endregion


        public Character(string name, int Age, int MaxAge, bool Sex, Character MainParent = null, Character SubParent = null)
        {
            this.Name = name;
            this.Age = Age;
            this.MaxAge = MaxAge;
            this.Sex = Sex;
            this.MainParent = MainParent;
            this.SubParent = SubParent;
            Resources = new List<GameResource>();
            Tags = new List<GameTag>();


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
            character.Spouse = this;
        }


        // public void IncreaseAge()
        // {
        //     Age++;
        //     if (Age > MaxAge)
        //     {
        //         Die();
        //         return;
        //     }
        //     if(this.GetSystem<GameSystem>().IsMainCharacter(this))
        //         this.SendEvent(new AgeChangeEvent(){Age = Age});
        //     this.GetSystem<GameEventSystem>().DrawEvent(this);
        //    
        // }

        public void IncreaseAge(int k)
        {
            ResetTempAttribute();
            Age += k;
            if (Age > MaxAge)
            {
                Die();
                return;
            }
            if (this.GetSystem<GameSystem>().IsMainCharacter(this))
                this.SendEvent(new AgeChangeEvent() { Age = Age });
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
            Resources.Remove(resource);
            this.SendEvent(new GetNewResourcesEvent(){Resources = Resources});
        }


        /// <summary>
        /// ???Tag
        /// </summary>
        /// <param name="tag"></param>
        public void GetTag(GameTag tag)
        {
            if (Tags == null)
            {
                Tags = new List<GameTag>();
            }
            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].TagGroupId == tag.TagGroupId)
                {
                    Tags.Remove(Tags[i]);
                }
            }
            Tags.Add(tag);
        }


        /// <summary>
        /// ?????????งน
        /// </summary>
        /// <returns></returns>
        public void SetTempAttribute()
        {
            foreach (KeyValuePair<int, int> pair in TempAttr)
            {
                switch (pair.Key)
                {
                    case (int)AttriType.LINGLI:
                        LINGLI += pair.Value;
                        break;
                    case (int)AttriType.SHENSHI:
                        SHENSHI += pair.Value;
                        break;
                    case (int)AttriType.BOWEN:
                        BOWEN += pair.Value;
                        break;
                    case (int)AttriType.XINGYUN:
                        XINGYUN += pair.Value;
                        break;
                }
            }
        }


        public void ResetTempAttribute()
        {
            foreach (KeyValuePair<int, int> pair in TempAttr)
            {
                switch (pair.Key)
                {
                    case (int)AttriType.LINGLI:
                        LINGLI -= pair.Value;
                        break;
                    case (int)AttriType.SHENSHI:
                        SHENSHI -= pair.Value;
                        break;
                    case (int)AttriType.BOWEN:
                        BOWEN -= pair.Value;
                        break;
                    case (int)AttriType.XINGYUN:
                        XINGYUN -= pair.Value;
                        break;
                }
            }
            TempAttr.Clear();
        }



        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
    }
}