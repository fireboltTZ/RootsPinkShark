using System;
using cfg;
using MatchThree.System;
using QFramework;
using Roots.Event;
using UnityEngine;
using EventType = cfg.EventType;

namespace Roots.Game
{
    public class EventExecutor : Singleton<EventExecutor>, ICanGetSystem, ICanSendEvent
    {

        private EventExecutor()
        {
            
        }
        public bool EventAvailable(Character character, cfg.Event evt)
        {
            if (evt.IsGenUnique && character.DoneEvents.Contains(evt.EventId))
            {
                return false;
            }
            if (evt.IsAllUnique && this.GetSystem<GameSystem>().HisDoneEvents.Contains(evt.EventId))
            {
                return false;
            }
            bool available = true;
            for (int i = 0; i < evt.AppearCondition.Count; i++)
            {
                available &= ConditionAvailable(character, evt.AppearCondition[i]);
            }
            return available;
        }


        public bool ConditionAvailable(Character character, cfg.EventCondition condition)
        {
            if (condition == null)
            {
                return true;
            }
            switch (condition.EventConditionName)
            {

                case EffectCondition.AGEBETWEEN:
                    if(character.Age>condition.Para1 && character.Age<condition.Para2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case EffectCondition.HAS_CHILDREN:
                    if (character.Children.Count != 0 && condition.Para1 == 1 || character.Children.Count == 0 && condition.Para1 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case EffectCondition.THIS_HAVEDONE:
                    return character.DoneEvents.Contains(condition.Para1);
                    break;
                case EffectCondition.ALL_HAVEDONE:
                    return this.GetSystem<GameSystem>().HisDoneEvents.Contains( condition.Para1);
                    break;
                case EffectCondition.ATTRIMINNEED:
                    switch (condition.Para1)
                    {
                        case (int)AttriType.LINGLI:
                            if(character.LINGLI >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case (int)AttriType.SHENSHI:
                            if(character.SHENSHI >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        case (int)AttriType.BOWEN:
                            if (character.BOWEN >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        case (int)AttriType.XINGYUN:
                            if (character.XINGYUN >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case (int)AttriType.GUIQI:
                            if (character.GUI >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case (int)AttriType.MOXI:
                            if (character.YAO >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case (int)AttriType.XIANYUN:
                            if (character.XIAN >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case (int)AttriType.FOGUANG:
                            if (character.FO >= condition.Para2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                    }
                    break;
                case EffectCondition.HAVETAG:
                    for(int i = 0; i < character.Tags.Count; i++)
                    {
                        if (character.Tags[i].TagId == condition.Para2)
                        {
                            return true;
                        }
                    }

                    return false;

                case EffectCondition.HAVERES:
                    for (int i = 0; i < character.Resources.Count; i++)
                    {
                        if (character.Resources[i].ResourceId == condition.Para2)
                        {
                            return true;
                        }
                    }

                    return false;


                case EffectCondition.HAS_PARTENER:
                    if (condition.Para1 == 0)
                    {
                        return character.Spouse == null || character.Spouse.CharacterState is CharacterState.Die or CharacterState.Retired;
                    }
                    else
                    {
                        return character.Spouse != null;
                    }
                 
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //available = false;
            return true;
        }

        public void EventExecute(Character character, cfg.Event evt)
        {
            if (evt.IsInteractive)
            {
                this.SendEvent<TimeStopEvent>();
                UIKit.OpenPanel<UIOptionPanel>(new UIOptionPanelData(){Event = evt});
            }
            else
            {
                ResourceExecutor.Instance.EventEffect(character, evt);
                
            }
            character.DoneEvents.Add(evt.EventId);
            this.GetSystem<GameSystem>().HisDoneEvents.Add(evt.EventId);
        }
        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
        
        

    }
}