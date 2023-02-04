using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UICharacterPanelData : UIPanelData
	{
	}
	public partial class UICharacterPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UICharacterPanelData ?? new UICharacterPanelData();
			// please add init code here
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
