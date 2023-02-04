using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:e5647542-c2d2-4c5b-b147-1d8ba93bd79e
	public partial class UIInheritPanel
	{
		public const string Name = "UIInheritPanel";
		
		
		private UIInheritPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIInheritPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIInheritPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIInheritPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
