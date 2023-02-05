using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UIEndPanelData : UIPanelData
	{
		
	}
	public partial class UIEndPanel : MyUIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIEndPanelData ?? new UIEndPanelData();
			// please add init code here
			
			Image.onClick.AddListener(() =>
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
