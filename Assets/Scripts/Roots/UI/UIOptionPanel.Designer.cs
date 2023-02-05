using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:fb4da8f0-3187-4e9c-a193-969a8de82ab3
	public partial class UIOptionPanel
	{
		public const string Name = "UIOptionPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI Title;
		[SerializeField]
		public TMPro.TextMeshProUGUI Desc;
		[SerializeField]
		public UnityEngine.UI.Image Slot1;
		[SerializeField]
		public UnityEngine.UI.Image Slot2;
		[SerializeField]
		public UnityEngine.UI.Image Slot3;
		[SerializeField]
		public UnityEngine.RectTransform BtnGroup;
		
		private UIOptionPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Title = null;
			Desc = null;
			Slot1 = null;
			Slot2 = null;
			Slot3 = null;
			BtnGroup = null;
			
			mData = null;
		}
		
		public UIOptionPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIOptionPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIOptionPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
