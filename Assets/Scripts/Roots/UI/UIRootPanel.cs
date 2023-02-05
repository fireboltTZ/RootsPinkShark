using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Roots.Game;
using System.Collections.Generic;
using System.Collections;
using static PixelCrushers.DialogueSystem.UnityGUI.GUIProgressBar;
using Unity.VisualScripting;
using static UnityEditor.PlayerSettings;
using System;
using System.Net;
using Unity.Mathematics;
using UnityEngine.UI.Extensions;
using MatchThree.System;
using cfg;

namespace Roots
{	public class UIRootPanelData : UIPanelData
	{

    }
	public partial class UIRootPanel : MyUIPanel //???????
	{
        public Character FirstMainChracter;
        public List<Character> CharacterList;
		public RectTransform OriginRect;
		public float Angle = 30f;
        public GameObject lineRenderer;
        public GameObject FamilyCardPrefab;
        public float Height = 400f;
        public GameObject Content;
        public Character SelectedChracter;


        public float MaxAngle; //branch max Angles
        protected override void OnInit(IUIData uiData = null)
		{
            
            mData = uiData as UIRootPanelData ?? new UIRootPanelData();
            // please add init code here
            FirstMainChracter = GameSystem.firstMainCharacter;
            DrawTree(OriginRect.anchoredPosition, MaxAngle, FirstMainChracter);

            Inherit_button.onClick.AddListener(()=>Inherit(SelectedChracter));
            Back_button.onClick.AddListener(()=>Back());

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

        public void SetSelectedCharacter(Character person)
        {
            SelectedChracter = person;        
        }
        
        public void DrawTree(Vector2 origin, float maxAngle, Character person)
		{
            float growthRate = 1f; //MaxAngle Decline Rate

            maxAngle = maxAngle * growthRate;
            IEnumerator enumerator()
            {
                var currentNode = Instantiate(FamilyCardPrefab, Content.transform,false);
                currentNode.GetComponent<RectTransform>().anchoredPosition = origin;
                //currentNode.GetComponent<UINameCard>().SelectCard()
                currentNode.GetComponent<UINameCard>().SetUpPerson(person);


                yield return new WaitForSeconds(1f);

                int numOfBranches = person.Children.Count; //UnityEngine.Random.Range(1, 5); 
                if (numOfBranches == 0) //Don't have child
                    yield return null;
                else 
                {
                    for (int i = 0; i < numOfBranches; i++)
                    {

                        var branchPoint = CaculateEndPoint(origin, 300, numOfBranches, i, maxAngle);
                        DrawLine(origin, branchPoint);
                        DrawTree(branchPoint, maxAngle, person.Children[i]);
                        //yield return new WaitForSeconds(1f);

                    }
                }
                


            }
            StartCoroutine(enumerator());


        }

        public void Inherit(Character person) 
        {
            if (person == null)
            {
                Debug.Log("Selected person is null!");
                return;
            }
            else
            {
                //?§Ø?Person??????????
                if (person.CharacterState != 0) //Not dead
                    OpenInheritPanel();
                //GameSystem.ChangeMainCharacter(person,new List<GameResource> items)
            }
        }


        void OpenInheritPanel()
        {
            
        }
        //private void 
        void DrawLine(Vector2 from, Vector2 to)
        {
            var lineprefab = Instantiate(lineRenderer, Content.transform, false);
            lineRenderer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            var branchRenderer = lineprefab.GetComponent<UILineRenderer>();

            Vector2 direction = to - from;
            
            Vector2 newFrom = from + direction.normalized * direction.magnitude*0.3f; 
            Vector2 newTo = from + direction.normalized * direction.magnitude * 0.85f;


            //branchRenderer.color = Color.red;
            branchRenderer.lineThickness = 70f;
            Vector2[] points= new Vector2[2];
            points[0]= newFrom; points[1]= newTo;
            branchRenderer.Points = points;

        }


        private Vector2 CaculateEndPoint(Vector2 startPoint, float length, int countOfbranches,int count, float maxAngle)
        {
            Debug.Log("CountofBranches: " + countOfbranches);
            //maxAngle = 120f;
            //Use Y Axis as

            float angleBetweenBranch = 0;
            if (countOfbranches <= 2)
                angleBetweenBranch = maxAngle;
            else
                angleBetweenBranch = maxAngle / (countOfbranches-1);
            Debug.Log("AngleB:"+angleBetweenBranch);
            float startAngle = maxAngle / 2;
            float currentAngle = startAngle - angleBetweenBranch * count;
            Debug.Log(currentAngle);

            Vector2 endPoint = startPoint;

            if (currentAngle > 0 && currentAngle < 90f)
            {

                float offset_X = Mathf.Tan(Mathf.Deg2Rad * currentAngle) * Height;
                //float offset_Y = MathF.Cos(Mathf.Deg2Rad * currentAngle) * length;
                endPoint.x = endPoint.x + offset_X;
                endPoint.y = endPoint.y - Height;

            }
            else if (currentAngle == 0)
            {
                float offset_X = Mathf.Tan(Mathf.Deg2Rad * currentAngle) * Height;
                //float offset_Y = MathF.Cos(Mathf.Deg2Rad * currentAngle) * length;
                endPoint.x = endPoint.x + offset_X;
                endPoint.y = endPoint.y - Height; 
            }

            else if (currentAngle < 0 && currentAngle > -90f)
            {
                float offset_X = Mathf.Tan(Mathf.Deg2Rad * -currentAngle) * Height;
                //float offset_Y = Mathf.Cos(Mathf.Deg2Rad * -currentAngle) * length;
                endPoint.x = endPoint.x - offset_X;
                endPoint.y = endPoint.y - Height;
            }

            else
            {
                Debug.Log("CurrentAngle out of range");
            }
            return endPoint;

        }

    }
}
