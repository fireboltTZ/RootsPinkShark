using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:d3adb21f-2d79-4694-b0ed-275d276f7603
	public partial class UIEndPanel
	{
		public const string Name = "UIEndPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button Image;
		[SerializeField]
		public UnityEngine.UI.Image EndImage;
		[SerializeField]
		public TMPro.TextMeshProUGUI EndTitle;
		[SerializeField]
		public TMPro.TextMeshProUGUI EndDesc;
		
		private UIEndPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Image = null;
			EndImage = null;
			EndTitle = null;
			EndDesc = null;
			
			mData = null;
		}
		
		public UIEndPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIEndPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIEndPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
