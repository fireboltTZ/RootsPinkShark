using System.Collections.Generic;
using QFramework;
using Roots.Event;
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

        public List<cfg.Event> DrawEvent(Character character)
        {
            List<cfg.Event> evt;
            if (this.GetSystem<GameSystem>().IsMainCharacter(character))
            {
                evt = ChooseEventFromAll(character);
            }
            else
            { 
                evt = ChooseEventFromNormal(character);
            }
            
            this.SendEvent(new GetNewEvent(){Events = evt});
            return evt;
        }

        public List<Event> DrawChildrenEvent(Character character)
        {
            return null;
        }


        private List<Event> ChooseEventFromAll(Character character)
        {
            return null;
        }

        private List<Event> ChooseEventFromNormal(Character character)
        {
            return null;
        }
    }
}