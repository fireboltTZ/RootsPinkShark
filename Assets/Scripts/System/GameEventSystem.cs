using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using QFramework;
using Roots.Event;
using Roots.Game;
using UnityEditor;
using UnityEngine;
using Utility;
using Event = cfg.Event;
using EventType = cfg.EventType;
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

        private List<Event> EventBase = new List<Event>();
        private List<Event> NormalEventBase = new List<Event>();
        private List<Event> MainCharacterEvents = new List<Event>();
        protected override void OnInit()
        {
            NormalEventBase.AddRange(GameSystem.Table.TbEvent.DataList.Where(e => e.EventType == EventType.Normal).ToList());
        }

        public void OnGenerationStart()
        {
            MainCharacterEvents.Clear();
            MainCharacterEvents.AddRange(this.GetSystem<GameSystem>().Table.TbEvent.DataList);
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
            
            this.SendEvent(new GetNewEvent(){Events = evt, Character = character});
            return evt;
        }
        

        private List<Event> ChooseEventFromAll(Character character)
        {
            List<Event> Evts = GameSystem.Table.TbEvent.DataList.Where(e => EventExecutor.Instance.EventAvailable(character, e)).ToList();
            List<List<Event>> List = Evts.GroupBy(e => e.DrawPri).Select(x => x.ToList()).ToList();
            List = List.OrderByDescending(o => o[0].DrawPri).ToList();
            int eventIndex = Random.Range(0, List[0].Count);
            foreach (var list in List)
            {
                foreach (var eEvent in list)
                {
                    Debug.LogFormat("EventID: {0}, EventPri: {1}, EventDesc: {2}", eEvent.EventId, eEvent.DrawPri, eEvent.Desc);
                }
            }
            List<Event> events = new List<Event>();
            
            events.Add(List[0][eventIndex]);
            return events;
        }

        private List<Event> ChooseEventFromNormal(Character character)
        {
            List<Event> Evts = GameSystem.Table.TbEvent.DataList.Where(e => e.EventType == EventType.Normal && EventExecutor.Instance.EventAvailable(character, e)).ToList();
            List<List<Event>> List = Evts.GroupBy(e => e.DrawPri).Select(x => x.ToList()).ToList();
            List = List.OrderByDescending(o => o[0].DrawPri).ToList();
            int eventIndex = Random.Range(0, List[0].Count);
            List<Event> events = new List<Event>();
            
            events.Add(List[0][eventIndex]);
            return events;
        }
    }
}