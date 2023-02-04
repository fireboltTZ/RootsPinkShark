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
        public List<Event> ChildNormalEvents = new List<Event>();
        public List<Event> ChildInteractiveEvents = new List<Event>();
        public List<Event> AdultNormalEvents = new List<Event>();
        public List<Event> AdultInteractiveEvents = new List<Event>();

        public GameSystem GameSystem => this.GetSystem<GameSystem>();
        protected override void OnInit()
        {
            
        }

        public List<cfg.Event> DrawEvent(Character character)
        {
            List<cfg.Event> evt;
            List<Event> EventBase = GameSystem.Table.TbEvent.DataList;
            if (GameSystem.IsMainCharacter(character))
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
            List<Event> Evts = new List<Event>();
            if (character.Age >= 18)
            {
                for (int i = 0; i < AdultInteractiveEvents.Count; i++)
                {
                    if (EventExecutor.Instance.EventAvailable(character, AdultInteractiveEvents[i]))
                    {
                        Evts.Add(AdultInteractiveEvents[i]);
                    }
                }
                for (int i = 0; i < AdultNormalEvents.Count; i++)
                {
                    if (EventExecutor.Instance.EventAvailable(character, AdultNormalEvents[i]))
                    {
                        Evts.Add(AdultNormalEvents[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < ChildInteractiveEvents.Count; i++)
                {
                    if (EventExecutor.Instance.EventAvailable(character, ChildInteractiveEvents[i]))
                    {
                        Evts.Add(ChildInteractiveEvents[i]);
                    }
                }
                for (int i = 0; i < ChildNormalEvents.Count; i++)
                {
                    if (EventExecutor.Instance.EventAvailable(character, ChildNormalEvents[i]))
                    {
                        Evts.Add(ChildNormalEvents[i]);
                    }
                }
            }
            int eventIndex = Random.Range(0, Evts.Count);
            List<Event> events = new List<Event>();
            events.Add(Evts[eventIndex]);
            return events;
        }

        private List<Event> ChooseEventFromNormal(Character character)
        {
            List<Event> Evts = new List<Event>();
            if (character.Age >= 18)
            {
                for (int i = 0; i < AdultNormalEvents.Count; i++)
                {
                    if (EventExecutor.Instance.EventAvailable(character, AdultNormalEvents[i]))
                    {
                        Evts.Add(AdultNormalEvents[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < ChildNormalEvents.Count; i++)
                {
                    if (EventExecutor.Instance.EventAvailable(character, ChildNormalEvents[i]))
                    {
                        Evts.Add(ChildNormalEvents[i]);
                    }
                }
            }
            int eventIndex = Random.Range(0, Evts.Count);
            List<Event> events = new List<Event>();
            events.Add(Evts[eventIndex]);
            return events;
        }
    }
}