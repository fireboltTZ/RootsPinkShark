using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:5ead5fa0-a315-4893-9d58-544f75225d30
	public partial class UICharacterPanel
	{
		public const string Name = "UICharacterPanel";
		
		
		private UICharacterPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UICharacterPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UICharacterPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UICharacterPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
