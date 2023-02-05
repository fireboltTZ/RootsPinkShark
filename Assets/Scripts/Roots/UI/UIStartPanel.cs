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
			AudioSystem.PlayMusic("bg1");
			mData = uiData as UIStartPanelData ?? new UIStartPanelData();
			// please add init code here
			StartBtn.onClick.AddListener(() =>
			{
				AudioSystem.PlayMusic("bg2");
				GameSystem.StartBattle();
			});
			QuitBtn.onClick.AddListener(() =>
			{
				GameSystem.QuitGame();
			});
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			
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
