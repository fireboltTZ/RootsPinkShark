using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:a3b084e9-58e4-4a2b-9b8c-f493489583a8
	public partial class UIEventPanel
	{
		public const string Name = "UIEventPanel";
		
		
		private UIEventPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIEventPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIEventPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIEventPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
