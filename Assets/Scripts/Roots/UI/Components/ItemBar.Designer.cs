/****************************************************************************
 * 2023.2 LAPTOP-GV07LFKI
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public partial class ItemBar
	{
		[SerializeField] public RectTransform Content;

		public void Clear()
		{
			Content = null;
		}

		public override string ComponentName
		{
			get { return "ItemBar";}
		}
	}
}
