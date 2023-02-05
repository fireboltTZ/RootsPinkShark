/****************************************************************************
 * 2023.2 LAPTOP-GV07LFKI
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public partial class AgeCanvas
	{
		[SerializeField] public TMPro.TextMeshProUGUI AgeNum;

		public void Clear()
		{
			AgeNum = null;

		}

		public override string ComponentName
		{
			get { return "AgeCanvas";}
		}
	}
}
