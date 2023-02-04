using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	
	public class UIEventPanelData : UIPanelData
	{
	}
	public partial class UIEventPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIEventPanelData ?? new UIEventPanelData();
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
