using DG.Tweening;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Roots.CharacterController;


namespace Roots
{
    public class CharacterController : MonoBehaviour
    {
        public enum Person
        {
            man,woman1,woman2
        }

        public Person person;

        public Image ManCloth;
        public Image ManFace;
        public Image ManShoes;
        public Image ManSkin;

        public Image Woman1Cloth;
        public Image Woman1Face;
        public Image Woman1Shoes;
        public Image Woman1Skin;

        public Image Woman2Cloth;
        public Image Woman2Face;
        public Image Woman2Shoes;
        public Image Woman2Skin;

        public GameObject Man;
        public GameObject Woman1;
        public GameObject Woman2;

        public List<Color> PresetClothColors = new List<Color>();
        public List<Color> PresetSkinColors = new List<Color>();
        public List<Color> PresetShoesColors = new List<Color>();
        
        public List<Sprite> PresetManFaces= new List<Sprite>();
        public List<Sprite> PresetWomannFaces = new List<Sprite>();

        public enum Emotion
        {
            Normal,Happy,Hit,Angry
        }

        public void Hitted()
        {
            ChangeFace(Emotion.Hit);
            this.GetComponent<RectTransform>().DOShakeAnchorPos(1f,10f,10,90,false,true);
        }

        public void Happy()
        {
            ChangeFace(Emotion.Happy);
            this.GetComponent<RectTransform>().DOShakeAnchorPos(2f, 20f, 7, 180, false, true);
        }

        public void Normal()
        {
            ChangeFace(Emotion.Normal);
            this.GetComponent<RectTransform>().DOShakeAnchorPos(3f, 50f, 4, 90, false, true);
        }

        public void Angry()
        {
             ChangeFace(Emotion.Angry);
            this.GetComponent<RectTransform>().DOShakeAnchorPos(1f, 10f, 10, 90, false, true);
        }

        public void ChangeFace(Emotion emotion)
        {
            if (person == 0)
                ManFace.sprite = PresetManFaces[(int)emotion];
            else if ((int)person == 1)
                Woman1Face.sprite = PresetWomannFaces[(int)emotion];
            else if((int)person == 2)
                Woman2Face.sprite = PresetWomannFaces[(int)emotion];
        }

        public void ChangeCloth(int index)
        {
            if (person == 0)
                ManCloth.color = PresetClothColors[index];
            else if ((int)person == 1)
                Woman1Cloth.color = PresetClothColors[index];
            else if ((int)person == 2)
                Woman2Cloth.color = PresetClothColors[index];
        }
        public void ChangeSkin(int index)
        {
            if (person == 0)
                ManSkin.color = PresetSkinColors[index];
            else if ((int)person == 1)
                Woman1Skin.color = PresetSkinColors[index];
            else if ((int)person == 2)
                Woman2Skin.color = PresetSkinColors[index];
        }
        public void ChangeShoes(int index)
        {
            if (person == 0)
                ManShoes.color = PresetShoesColors[index];
            else if ((int)person == 1)
                Woman1Shoes.color = PresetShoesColors[index];
            else if ((int)person == 2)
                Woman2Shoes.color = PresetShoesColors[index];
        }

        public void SetGender(int index)
        {
            if (index == 0)
            {
                person = Person.man;
                Man.SetActive(true);
                Woman1.SetActive(false);
                Woman2.SetActive(false);
            }
                
            else if (index == 1 || index == 2)
            {
                int num = Random.Range(1, 3);
                person = (Person)num;
                Man.SetActive(false);
                if ((int)person == 1)
                { 
                    Woman1.SetActive(true);
                    Woman2.SetActive(false);
                }
                else if ((int)person == 2)
                {
                    Woman1.SetActive(false);
                    Woman2.SetActive(true);
                }
            }

        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SetGender(2);
                ChangeFace(Emotion.Hit);
                ChangeCloth(3);
                ChangeSkin(2);
                ChangeShoes(2);
                Hitted();
            }

            //if (Input.GetKeyDown(KeyCode.N))
            //{
            //    ChangeFace(Emotion.Normal);
            //    Normal();
            //}

            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    ChangeFace(Emotion.Happy);
            //    Happy();
            //}

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    ChangeFace(Emotion.Angry);
            //    Angry();
            //}

        }
    }

}



