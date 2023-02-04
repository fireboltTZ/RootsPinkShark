using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:9fda7409-b6a8-439d-bfd0-d71f95128efd
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public ChasracterCanvas CharacterCanvas;
		[SerializeField]
		public AgeCanvas AgeBar;
		[SerializeField]
		public UnityEngine.UI.Image TagBar;
		[SerializeField]
		public EventCalendar EventCalender;
		[SerializeField]
		public ItemBar ItemBar;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			CharacterCanvas = null;
			AgeBar = null;
			TagBar = null;
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
