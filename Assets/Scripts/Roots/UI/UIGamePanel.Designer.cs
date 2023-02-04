using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:ec92cf1a-256b-46a1-9734-9e065f61bd99
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public ChasracterCanvas CharacterCanvas;
		[SerializeField]
		public AgeCanvas AgeBar;
		[SerializeField]
		public EventCalendar EventCalender;
		[SerializeField]
		public ItemBar ItemBar;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			CharacterCanvas = null;
			AgeBar = null;
			EventCalender = null;
			ItemBar = null;
			
			mData = null;
		}
		
		public UIGamePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
