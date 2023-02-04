using System;
using cfg;
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

                case EffectCondition.AGEBETWEEN:
                    if(character.Age>condition.Para1 && character.Age<condition.Para2)
                    {
                        available = true;
                        return true;
                    }
                    break;
                case EffectCondition.HAS_CHILDREN:
                    break;
                case EffectCondition.THIS_HAVEDONE:
                    break;
                case EffectCondition.ALL_HAVEDONE:
                    break;
                case EffectCondition.ATTRIMINNEED:
                    break;
                case EffectCondition.HAVETAG:
                    break;
                case EffectCondition.HAVERES:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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