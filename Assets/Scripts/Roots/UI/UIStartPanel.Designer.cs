using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	// Generate Id:0985da34-21d1-45a7-b13c-abe6e8a64606
	public partial class UIStartPanel
	{
		public const string Name = "UIStartPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button testBtn;
		[SerializeField]
		public UnityEngine.UI.Button StartBtn;
		[SerializeField]
		public UnityEngine.UI.Button QuitBtn;
		
		private UIStartPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			testBtn = null;
			StartBtn = null;
			QuitBtn = null;
			
			mData = null;
		}
		
		public UIStartPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIStartPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIStartPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
