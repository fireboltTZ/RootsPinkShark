using QFramework;
using Roots.Game;
using UnityEditor;
using UnityEngine;
using Event = cfg.Event;
using NotImplementedException = System.NotImplementedException;


namespace MatchThree.System
{
    //你好
    public class GameEventSystem : AbstractSystem
    {
        protected override void OnInit()
        {
            
        }

        public Event DrawEvent(Character character)
        {
            Event evt;
            if (this.GetSystem<GameSystem>().IsMainCharacter(character))
            {
                evt = ChooseEventFromAll(character);
            }
            else
            { 
                evt = ChooseEventFromNormal(character);
            }
            return evt;
        }


        private Event ChooseEventFromAll(Character character)
        {
            return null;
        }

        private Event ChooseEventFromNormal(Character character)
        {
            return null;
        }
    }
}