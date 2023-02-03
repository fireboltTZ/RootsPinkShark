using MatchThree.System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UIStartPanelData : UIPanelData
	{
	}
	public partial class UIStartPanel : MyUIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIStartPanelData ?? new UIStartPanelData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			StartBtn.onClick.AddListener(() =>
			{
				GameSystem.StartGame();
				this.GetSystem<GameSystem>().QuitGame();
			});
			QuitBtn.onClick.AddListener(() =>
			{
				GameSystem.QuitGame();
			});
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
