using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:55fc535d-be9d-4cfa-a138-3fbe9c41928e
	public partial class UIRootPanel
	{
		public const string Name = "UIRootPanel";
		
		
		private UIRootPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
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
