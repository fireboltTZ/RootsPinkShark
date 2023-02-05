using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:bb578590-a79e-4790-b0da-000a3a518b94
	public partial class UIAscendencePanel
	{
		public const string Name = "UIAscendencePanel";
		
		[SerializeField]
		public RectTransform ItemSlot0;
		[SerializeField]
		public RectTransform ItemSlot1;
		[SerializeField]
		public RectTransform ItemSlot2;
		[SerializeField]
		public RectTransform ItemSlot3;
		[SerializeField]
		public UnityEngine.UI.Button AscendenceBtn;
		
		private UIAscendencePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			ItemSlot0 = null;
			ItemSlot1 = null;
			ItemSlot2 = null;
			ItemSlot3 = null;
			AscendenceBtn = null;
			
			mData = null;
		}
		
		public UIAscendencePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIAscendencePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIAscendencePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
