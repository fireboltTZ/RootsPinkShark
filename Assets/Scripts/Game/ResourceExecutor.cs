using cfg;
using MatchThree.System;
using QFramework;
using Roots.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Roots.Game
{
    public class ResourceExecutor : Singleton<ResourceExecutor>, ICanGetSystem
    {
        public IArchitecture GetArchitecture()
        {
            throw new System.NotImplementedException();
        }


        //TODO:�ӵ������е�����Ʒ
        public GameResource DropResourceFromGroup(int groupId)
        {
            return null;
        }



        public void ResourceEffect(Character character, List<EventEffect> effects)
        {
            for(int i = 0; i < effects.Count; i++)
            {
                switch(effects[i].EffectType)
                {
                    case EffectType.GROWTH:
                        switch (effects[i].Para1)
                        {
                            case (int) AttriType.LINGLI:
                                character.LINGLI += effects[i].Para2;
                                break;
                            case (int) AttriType.SHENSHI:
                                character.SHENSHI += effects[i].Para2;
                                break;
                            case (int) AttriType.BOWEN:
                                character.BOWEN += effects[i].Para2;
                                break;
                            case (int)AttriType.XINGYUN:
                                character.XINGYUN += effects[i].Para2;
                                break;
                        }
                        break;
                    case EffectType.MARRY:
                        Character another = this.GetSystem<GameSystem>().CreateCharacter("", 18, 80, !character.Sex);
                        character.Marry(another);
                        break;
                    case EffectType.DIE:
                        character.Die();
                        break;
                    case EffectType.DIE_SON:
                        character.Children[effects[i].Para1].Die();
                        break;
                    case EffectType.ADD_RESOURCE:
                        character.Resources.Add(this.GetSystem<GameSystem>().Table.TbResource[effects[i].Para1]);
                        break;
                    case EffectType.ADD_MONEY:
                        for (int j = 0; j < effects[i].Para1; j++)
                        {
                            character.Resources.Add(this.GetSystem<GameSystem>().Table.TbResource[0000]);//Need Money ID
                        }
                        break;



                    case EffectType.ADD_CURR_EVENT:
                        break;
                    case EffectType.ADD_NEXT_EVENT:
                        break;
                    case EffectType.THIS_HAVEDONE:
                        break;
                    case EffectType.ALL_HAVEDONE:
                        break;
                    case EffectType.HEARTGROWTH:
                        break;



                    case EffectType.TAGACTIVE:
                        character.GetTag(this.GetSystem<GameSystem>().Table.TbTag[effects[i].Para1]);
                        break;
                    case EffectType.AGECHANGE:
                        character.Age += effects[i].Para1;
                        break;
                    case EffectType.DROP:
                        character.Resources.Add(DropResourceFromGroup(effects[i].Para1));
                        break;
                    case EffectType.TATTRI:
                        if (character.TempAttr.ContainsKey(effects[i].Para1))
                        {
                            character.TempAttr[effects[i].Para1] += effects[i].Para1;
                        }
                        else
                        {
                            character.TempAttr.Add(effects[i].Para1, effects[i].Para2);
                        }
                        character.SetTempAttribute();
                        break;
                }
            }
        }
    }
}
