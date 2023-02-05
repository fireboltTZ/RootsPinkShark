using cfg;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEditor;

namespace Roots
{
	public class UIOptionPanelData : UIPanelData
	{
		public cfg.Event Event;

	}
	public partial class UIOptionPanel : UIPanel
	{
		public EventOptionButton OptionPrefab;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIOptionPanelData ?? new UIOptionPanelData();
			// please add init code here
			Title.text = mData.Event.EventName;
			Desc.text = mData.Event.Desc;
			foreach (var i in mData.Event.Options)
			{
				EventOptionButton btn = Instantiate(OptionPrefab, BtnGroup.transform);
				btn.EventOptionInit(i);
				
			}
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
