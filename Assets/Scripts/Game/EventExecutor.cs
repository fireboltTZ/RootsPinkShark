using MatchThree.System;
using QFramework;
using UnityEngine;

namespace Roots.Game
{
    public class EventExecutor : Singleton<EventExecutor>, ICanGetSystem
    {

        public bool EventAvailable(Character character, cfg.Event evt)
        {
            if (evt.IsGenUnique && this.GetSystem<GameSystem>().GenUnique.Contains(evt.EventId))
            {
                return false;
            }
            if (evt.IsAllUnique && this.GetSystem<GameSystem>().HistUnique.Contains(evt.EventId))
            {
                return false;
            }
            bool available = false;
            for (int i = 0; i < evt.AppearCondition.Count; i++)
            {
                ConditionAvailable(character, evt.AppearCondition[i], ref available);
            }
            return available;
        }


        public bool ConditionAvailable(Character character, cfg.EventCondition condition, ref bool available)
        {
            switch (condition.EventConditionName)
            {
                case "Age":
                    if(character.Age>condition.Para1 && character.Age<condition.Para2)
                    {
                        available = true;
                        return true;
                    }
                    break;
            }
            available = false;
            return false;
        }

        public IArchitecture GetArchitecture()
        {
            throw new System.NotImplementedException();
        }

    }
}