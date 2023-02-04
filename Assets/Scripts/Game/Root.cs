using System.Collections;
using System.Collections.Generic;
using System.IO;
using QFramework;
using UnityEngine;
using cfg;
using MatchThree.System;
using PixelCrushers.DialogueSystem.ChatMapper;
using SimpleJSON;

namespace Roots.Game
{


    public class Root : QMonoBehaviour, ICanGetSystem
    {
        // Start is called before the first frame update
        void Start()
        {
            //var tables = new Tables(Loader);
            
            this.GetSystem<GameSystem>().StartGame();
        }

        private JSONNode Loader(string fileName)
        {
            return JSON.Parse(
                File.ReadAllText((Application.dataPath + "/../GeneratedDatas/json/" + fileName + ".json")));
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override IManager Manager { get; }

        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
    }
}
