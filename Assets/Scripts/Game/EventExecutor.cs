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
                    if (character.Children.Count != 0 && condition.Para1 == 1 || character.Children.Count == 0 && condition.Para1 == 0)
                    {
                        available= true;
                        return true;
                    }
                    break;
                case EffectCondition.THIS_HAVEDONE:
                    //TODO
                    break;
                case EffectCondition.ALL_HAVEDONE:
                    //TODO
                    break;
                case EffectCondition.ATTRIMINNEED:
                    switch (condition.Para1)
                    {
                        case (int)AttriType.LINGLI:
                            if(character.LINGLI >= condition.Para2)
                            {
                                available = true;
                                return true;
                            }
                            break;
                        case (int)AttriType.SHENSHI:
                            if(character.SHENSHI >= condition.Para2)
                            {
                                available = true;
                                return true;
                            }
                            break;
                        case (int)AttriType.BOWEN:
                            if (character.BOWEN >= condition.Para2)
                            {
                                available = true;
                                return true;
                            }
                            break;
                        case (int)AttriType.XINGYUN:
                            if (character.XINGYUN >= condition.Para2)
                            {
                                available = true;
                                return true;
                            }
                            break;
                    }
                    break;
                case EffectCondition.HAVETAG:
                    for(int i = 0; i < character.Tags.Count; i++)
                    {
                        if (character.Tags[i].TagId == condition.Para2)
                        {
                            available = true;
                            return true;
                        }
                    }
                    break;
                case EffectCondition.HAVERES:
                    for (int i = 0; i < character.Resources.Count; i++)
                    {
                        if (character.Resources[i].ResourceId == condition.Para2)
                        {
                            available = true;
                            return true;
                        }
                    }
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