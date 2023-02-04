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

namespace Roots
{	public class UIRootPanelData : UIPanelData
	{
        public List<Character> CharacterList;
        public GameObject FamilyCardPrefab;
		public Vector3 Origin;
        public Vector3 End;
		public float Angle;
        public float Height;
        
    }
	public partial class UIRootPanel : UIPanel //¼Ò×åÍ¼Æ×
	{
		public RectTransform Start;
		public RectTransform End;
		public float Angle = 30f;
        public GameObject lineRenderer;
        public GameObject FamilyCardPrefab;

        public float MaxAngle = 180f;
        protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIRootPanelData ?? new UIRootPanelData();
			// please add init code here
			DrawTree(End.anchoredPosition, MaxAngle);
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
        
        public void DrawTree(Vector2 origin, float maxAngle)
		{
            float growthRate = 0.9f;
            maxAngle = maxAngle * growthRate;
            IEnumerator enumerator()
            {
                var currentBranch = Instantiate(FamilyCardPrefab,this.transform,false);
                currentBranch.GetComponent<RectTransform>().anchoredPosition = origin;
                yield return new WaitForSeconds(1f);

                int numOfBranches = UnityEngine.Random.Range(1, 4);
                //if (numOfBranches == 0)
                 //   yield return null;
                for (int i = 0; i < numOfBranches; i++)
                {

                    var branchPoint = CaculateEndPoint(origin, 300, numOfBranches, i, maxAngle);
                    DrawLine(origin, branchPoint);
                    DrawTree(branchPoint, maxAngle);
                    //yield return new WaitForSeconds(1f);

                }


            }
            StartCoroutine(enumerator());


        }

        //private void 
        void DrawLine(Vector2 from, Vector2 to)
        {
            var lineprefab = Instantiate(lineRenderer, this.transform, false);
            lineRenderer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            var branchRenderer = lineprefab.GetComponent<LineRenderer>();

            branchRenderer.startColor = Color.red;
            branchRenderer.endColor = Color.red;
            branchRenderer.startWidth = 0.1f;
            branchRenderer.endWidth = 0.1f;
            branchRenderer.positionCount = 2;
            branchRenderer.useWorldSpace = false;

            branchRenderer.SetPosition(0, from); //x,y and z position of the starting point of the line
            branchRenderer.SetPosition(1, to); //x,y and z position of the end point of the line

            
            Debug.DrawLine(from, to, Color.green);
        }


        private Vector2 CaculateEndPoint(Vector2 startPoint, float length, int countOfbranches,int count, float maxAngle)
        {
            Debug.Log("CountofBranches: " + countOfbranches);
            //Use Y Axis as
            maxAngle = 120;
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

                float offset_X = Mathf.Sin(Mathf.Deg2Rad * currentAngle) * length;
                float offset_Y = MathF.Cos(Mathf.Deg2Rad * currentAngle) * length;
                endPoint.x = endPoint.x + offset_X;
                endPoint.y = endPoint.y + offset_Y;

            }
            else if (currentAngle == 0)
            {
                float offset_X = Mathf.Sin(Mathf.Deg2Rad * currentAngle) * length;
                float offset_Y = MathF.Cos(Mathf.Deg2Rad * currentAngle) * length;
                endPoint.x = endPoint.x + offset_X;
                endPoint.y = endPoint.y + offset_Y;
            }

            else if (currentAngle < 0 && currentAngle > -90f)
            {
                float offset_X = Mathf.Sin(Mathf.Deg2Rad * -currentAngle) * length;
                float offset_Y = Mathf.Cos(Mathf.Deg2Rad * -currentAngle) * length;
                endPoint.x = endPoint.x - offset_X;
                endPoint.y = endPoint.y + offset_Y;
            }

            else
            {
                Debug.Log("CurrentAngle out of range");
            }
            return endPoint;

        }

    }
}
