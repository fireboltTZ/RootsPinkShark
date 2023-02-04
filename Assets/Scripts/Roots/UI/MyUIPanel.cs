using MatchThree.System;
using QFramework;
using Unity.VisualScripting;

namespace Roots
{
    public class MyUIPanel : UIPanel, ICanGetSystem, ICanRegisterEvent
    {
        public GameSystem GameSystem => this.GetSystem<GameSystem>();
        public AudioSystem AudioSystem => this.GetSystem<AudioSystem>();
        protected override void OnClose()
        {
            
        }

        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }
    }
}