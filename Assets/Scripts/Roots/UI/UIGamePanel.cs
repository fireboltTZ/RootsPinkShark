using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : MyUIPanel
	{
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            // please add init code here
            //����
            //
            //����
            //DragAndDrop
            //
			//Item.GetComponent<DragAndDrop>().OnBeginDrag.AddListener(() => { })
			
			
			

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
