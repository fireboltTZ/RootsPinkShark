/****************************************************************************
 * 2023.2 LAPTOP-GV07LFKI
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Roots
{
	public partial class ChasracterCanvas
	{
		[SerializeField] public TMPro.TextMeshProUGUI LING;
		[SerializeField] public TMPro.TextMeshProUGUI QIAO;
		[SerializeField] public TMPro.TextMeshProUGUI ZHI;
		[SerializeField] public TMPro.TextMeshProUGUI YUN;
		[SerializeField] public TMPro.TextMeshProUGUI QIAN;
		[SerializeField] public TMPro.TextMeshProUGUI YAO;
		[SerializeField] public TMPro.TextMeshProUGUI XIAN;
		[SerializeField] public TMPro.TextMeshProUGUI MO;
		[SerializeField] public TMPro.TextMeshProUGUI FO;

		public void Clear()
		{
			LING = null;
			QIAO = null;
			ZHI = null;
			YUN = null;
			QIAN = null;
			YAO = null;
			XIAN = null;
			MO = null;
			FO = null;
		}

		public override string ComponentName
		{
			get { return "ChasracterCanvas";}
		}
	}
}
