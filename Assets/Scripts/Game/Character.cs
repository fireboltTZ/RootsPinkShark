using System.Collections.Generic;
using cfg;
using MatchThree.System;
using QFramework;
using Unity.VisualScripting;

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

        public Character MainParent;
        public Character SubParent;
        public List<Character> Children;
        
        #endregion

        public void Die()
        {
            
        }

        public void Retired()
        {
            
        }

        public void IncreaseAge()
        {
            Age++;
            this.GetSystem<GameEventSystem>().DrawEvent(this);
            
        }

//TODO
        private List<Character> GetAllChildren()
        {
            return null;
        }
        public void UseResource()
        {
            
        }

        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
    }
}