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

        public void ResourceEffect(Character character, List<EventEffect> effects)
        {
            for(int i = 0; i < effects.Count; i++)
            {
                switch(effects[i].EventEffectType)
                {
                    case EffectType.GROWTH:
                        switch (effects[i].Para1)
                        {
                            case 0:
                                character.Strength += effects[i].Para2;
                                break;
                            case 1:
                                character.Agility += effects[i].Para2;
                                break;
                            case 2:
                                character.Intelligence += effects[i].Para2;
                                break;
                        }
                        break;
                    case EffectType.MARRY:
                        Character another = this.GetSystem<GameSystem>().CreateCharacter("", 18, 80, !character.Sex);
                        character.Marry(another);
                        break;
                }
            }
        }
    }
}
