using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{	public class UIRootPanelData : UIPanelData
	{
	}
	public partial class UIRootPanel : UIPanel //¼Ò×åÍ¼Æ×
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIRootPanelData ?? new UIRootPanelData();
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
