using System.Collections.Generic;
using cfg;
using ModelShark;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Roots.Event;
using Roots.Game;

namespace Roots
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : MyUIPanel, ICanSendEvent
	{
		public GameTagObject GameTagObjectPrefab;
		public GameItem GameItemPrefab;
		public GameLog GameLogPrefab;
		public AgeBar AgeSlider;
		public Button InheritBtn;
		public Button AscendenceBtn;
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
			this.GetComponent<TooltipManager>().guiCamera = UIKit.Root.Camera;
			InheritBtn.onClick.AddListener(() =>
			{
				UIKit.OpenPanel<UIRootPanel>(new UIRootPanelData(){});
				this.SendEvent<TimeStopEvent>();
			});
			AscendenceBtn.onClick.AddListener(() =>
			{
				this.SendEvent<TimeStopEvent>();
				UIKit.OpenPanel<UIAscendencePanel>();
			});
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
					EventExecutor.Instance.EventExecute(e.Character,gameEvent);
				}
			});
			
			this.RegisterEvent<GetNewNotificationEvent>(e =>
			{
				GameLog gl = Instantiate(GameLogPrefab, EventCalender.Content.transform);
				gl.Text.text = e.s;
				gl.Text.color = e.Color;
			});

			this.RegisterEvent<GetNewTagEvent>(e =>
			{
				SetNewTag(e.Tags);
			});

			this.RegisterEvent<GetNewResourcesEvent>(e =>
			{
				SetNewResources(e.Resources);
			});

			this.RegisterEvent<TimeStopEvent>(e =>
			{
				AgeSlider.Stop();
			});

			this.RegisterEvent<TimeContinueEvent>(e =>
			{
				AgeSlider.Play();
			});
 
			this.RegisterEvent<NormalGameLogEvent>(e =>
			{
				NormalGameLog(e.content);
			});


			this.RegisterEvent<ShowResourceTagEvent>(e =>
			{

			});

            this.RegisterEvent<ShowInfoTagEvent>(e =>
            {

            });
        }


		private void NormalGameLog(string content)
		{
			GameLog gl = Instantiate(GameLogPrefab, EventCalender.Content.transform);
			gl.Text.text = content;
        }

		private void SetNewTag(List<GameTag> list)
		{
			TagBar.transform.DestroyChildren();
			foreach (var gameTag in list)
			{
				GameTagObject gto = Instantiate(GameTagObjectPrefab, TagBar.transform);
				gto.Init(gameTag);
			}
		}
		
		private void SetNewResources(List<GameResource> list)
		{
			ItemBar.Content.transform.DestroyChildren();
			foreach (var gameResource in list)
			{
				GameItem gto = Instantiate(GameItemPrefab, ItemBar.Content.transform);
				gto.Init(gameResource);
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
