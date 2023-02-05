using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public class UIAscendencePanelData : UIPanelData
	{
	}
	public partial class UIAscendencePanel : MyUIPanel
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
			if (GameSystem.MainCharacter.FO >= 10)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 1});
			}
			else if (GameSystem.MainCharacter.FO >= 5)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 2});
			}
			else if (GameSystem.MainCharacter.GUI >= 10)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 3});
			}
			else if (GameSystem.MainCharacter.GUI >= 5)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 4});
			}
			else if (GameSystem.MainCharacter.XIAN >= 10)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 5});
			}
			else if (GameSystem.MainCharacter.XIAN >= 5)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 6});
			}
			else if (GameSystem.MainCharacter.YAO >= 10)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 7});
			}else if (GameSystem.MainCharacter.YAO >= 5)
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 8});
			}
			else
			{
				UIKit.OpenPanel<UIEndPanel>(new UIEndPanelData() {Endings = 9});
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
