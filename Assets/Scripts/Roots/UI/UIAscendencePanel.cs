using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UIAscendencePanelData : UIPanelData
	{
	}
	public partial class UIAscendencePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIAscendencePanelData ?? new UIAscendencePanelData();
			// please add init code here
			AscendenceBtn.onClick.AddListener(() =>
			{
				TryAscendence();
			});
		}

		//TODO
		private void TryAscendence()
		{
			throw new System.NotImplementedException();
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
