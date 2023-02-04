using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Roots.Event;

namespace Roots
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : MyUIPanel
	{
		public GameTagObject GameTagObjectPrefab;
		public GameItem GameItemPrefab;
		public GameLog GameLogPrefab;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            // please add init code here
            //±³°ü
            //
            //µ¯´°
            //DragAndDrop
            //
			//Item.GetComponent<DragAndDrop>().OnBeginDrag.AddListener(() => { })

			this.RegisterEvent<AgeChangeEvent>(e =>
			{
				AgeBar.AgeNum.text = e.Age.ToString();
			});

			this.RegisterEvent<GetNewEvent>(e =>
			{
				foreach (var gameEvent in e.Events)
				{
					GameLog gl = Instantiate(GameLogPrefab, EventCalender.Content.transform);
					gl.Text.text = gameEvent.Desc;
				}
			});

			this.RegisterEvent<GetNewTagEvent>(e =>
			{
				
			});

			this.RegisterEvent<GetNewResourcesEvent>(e =>
			{

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
