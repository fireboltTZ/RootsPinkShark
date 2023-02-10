using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Unity.VisualScripting;
using UnityEditor;

namespace Roots
{
	public class UIEndPanelData : UIPanelData
	{
		public int Endings;
	}
	public partial class UIEndPanel : MyUIPanel
	{
		private ResLoader _resLoader = ResLoader.Allocate();
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIEndPanelData ?? new UIEndPanelData();
			// please add init code here
			
			Image.onClick.AddListener(() =>
			{
				GameSystem.QuitGame();
			});
			if (mData.Endings == 9)
			{
				mData.Endings = Random.Range(1, 9);}
			switch (mData.Endings)
			{

				//fo2
				case 6:
					EndDesc.text = "从此你直上青云，翻手为云覆手为雨，风雨雷电皆为你所用。散为气，聚为神，平衡人间秩序，斩妖除魔，除尽世间不平之事。";
					EndTitle.text = "九天玄仙";
					EndImage.sprite = Resources.Load<Sprite>("ending/XIAN1");
					break;
				//fo1
				case 5:
					EndDesc.text = "金色龙辇浮于云端，你坐在龙辇中百无聊赖的随意滑动着手指。一颗龙珠跟随手指肆意飞舞着，而拉车的九条金龙被龙珠逗弄的死死缠在了一起。你轻轻撇了一眼几条金龙，显得有些无可奈何。随手一挥，九条金龙已然回到车架前，乖乖拉着龙辇急速消失于天边。也正是这一夜，人间战乱的七国纷纷偃旗息鼓，停止了掠夺他国的步伐。七国子民皆以为这是皇帝们的功劳，却不知是有人在默默制定着人间的秩序。";
					EndTitle.text = "紫微帝君";
					EndImage.sprite = Resources.Load<Sprite>("ending/XIAN2");
					break;
				//gui2
				case 4:
					EndDesc.text = "你以凡胎肉体踏入鬼仙之道，凡人死去后，灵魂变得混沌，紧接着就消散。但你成为了一个神志清晰，游荡世间的存在，不再拥有实体，冷漠的观察着世间的一切，直到永远…";
					EndTitle.text = "赤面鬼君";
					EndImage.sprite = Resources.Load<Sprite>("ending/GUI2");
					break;
				case 3:
					EndDesc.text = "你坐到了鬼木轿子上，道心平稳，鬼气四溢。渐渐的，天色似乎变得暗淡了起来。身边渐渐多出一个..两个..三个...紧接着是无数个与你长相一模一样的黑影。霎时间人头攒动，逐渐形成一条黑色的长龙队伍，向着不知为何处的目的地前行，他们嬉笑着抬起轿子，你渐渐也被情绪浸染，挥手起轿。阴冷之气在世间窜动，你掀起的游行永不停歇，在每一个无月的黑夜，人们都能在微弱灯火摇曳的瞬间，瞅见百鬼夜行的骇人盛况。";
					EndTitle.text = "白面鬼帝";
					EndImage.sprite = Resources.Load<Sprite>("ending/GUI1");
					break;
				//xian
				case 2:
					EndDesc.text = "即使万千劫难加身，唯你心不可动摇，如山如石。无论世事如何变迁，山在你在。从此行走人世间普度众生，化解凡人疾苦。弹指挥间可感化妖邪，让人心无杂念。";
					EndTitle.text = "藏识罗汉";
					EndImage.sprite = Resources.Load<Sprite>("ending/FO2");
					break;
				case 1:
					EndDesc.text = "你飞升之时正是黑夜，西方却耀出万丈佛光，照得人间大地恍如白日。人间所有寺庙鸣钟不止，亿万信徒跪俯于地，虔诚的向着西方朝拜。佛光中隐约透出一道身影，后世人皆称自己所看到的是真佛，可每个人看到的面孔竟都不一样。千人看佛，佛有千面，诸相如幻，你作为佛在亿万信徒心中留下善念。刹那间佛光消失，仿佛从来没有出现过，可无数善念的种子会在人间生根发芽。";
					EndTitle.text = "大须弥佛";
					EndImage.sprite = Resources.Load<Sprite>("ending/FO1");
					break;
				//yao
				case 7:
					EndDesc.text = "抬手间，一只赤色的九尾小狐狸出现在你怀中。它奋力用头拱着你的胸口，一副很享受的样子。一眨眼的功夫小狐狸不见了，出现在你掌间的是一只发着活泼的彩雀。一只只灵动的妖兽在你手中不断变换着，人间有的，人间没有的。最终，你手中的妖兽化成一群彩蝶，消散于天地间。你轻轻笑了笑，从云端看向脚下的山林。山林里的妖兽仿佛受到了无形的呼唤，不约而同的抬头看向他们的王，看向那位可以赐予它们生命，决定他们生死的神明。";
					EndTitle.text = "不灭妖灵";
					EndImage.sprite = Resources.Load<Sprite>("ending/YAO2");
					break;
				case 8:
					EndDesc.text = "你以凡人之躯，替血换骨，成为山间精灵，获得百变之能。举手投足摄人心魂，能够蛊惑人心。从此人间再无难事，逍遥世间千万载。";
					EndTitle.text = "灵魅妖仙";
					EndImage.sprite = Resources.Load<Sprite>("ending/YAO1");
					break;
				case 9:
					EndDesc.text = "元宵佳节之际";
					EndTitle.text = "正道飞升";
					EndImage.sprite = Resources.Load<Sprite>("ending/PUTONG");
					break;
					
			}
			
			
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
