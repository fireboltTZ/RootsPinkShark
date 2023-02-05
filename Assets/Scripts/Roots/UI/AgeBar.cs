using MatchThree.System;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Roots
{


    public class AgeBar : MonoBehaviour, ICanGetSystem
    {
        public Image Slider;
        public float AgePassTime = 5f;
        private bool IsStop = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(!IsStop)
                Slider.fillAmount += Time.deltaTime/AgePassTime;
            if (Slider.fillAmount >= 1)
            {
                this.GetSystem<GameSystem>().GameTimePass();
                Slider.fillAmount = 0;
            }
        }

        public void Stop()
        {
            IsStop = true;
        }

        public void Play()
        {
            IsStop = false;
        }

        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
    }
}
