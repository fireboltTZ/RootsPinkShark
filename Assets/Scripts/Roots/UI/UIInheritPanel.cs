using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UIInheritPanelData : UIPanelData
	{
	}
	public partial class UIInheritPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIInheritPanelData ?? new UIInheritPanelData();
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
