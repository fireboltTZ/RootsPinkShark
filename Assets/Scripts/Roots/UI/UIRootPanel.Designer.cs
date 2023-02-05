using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:669c33e1-afd4-48c0-bc7c-98b9ce2ed1f8
	public partial class UIRootPanel
	{
		public const string Name = "UIRootPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button Back_button;
		[SerializeField]
		public UnityEngine.UI.Button Inherit_button;
		
		private UIRootPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Back_button = null;
			Inherit_button = null;
			
			mData = null;
		}
		
		public UIRootPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIRootPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIRootPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
