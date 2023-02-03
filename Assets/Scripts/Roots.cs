using System.Collections;
using System.Collections.Generic;
using MatchThree.System;
using UnityEngine;
using QFramework;
using cfg;
namespace Roots
{
    public class Roots : Architecture<Roots>
    {
        protected override void Init()
        {
            RegisterSystem(new GameSystem());
            RegisterSystem(new AudioSystem());
            RegisterSystem(new GameEventSystem());
        }
    }

}
