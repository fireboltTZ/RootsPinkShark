using DG.Tweening;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Roots
{
    public class CharacterController : MonoBehaviour
    {
        public Image Cloth;
        public Image Face;
        public Image Shoes;
        public Image Skin;


        public List<Color> PresetClothColors = new List<Color>();
        public List<Color> PresetSkinColors = new List<Color>();
        public List<Color> PresetShoesColors = new List<Color>();
        public List<Sprite> PresetFaces= new List<Sprite>();

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
            Face.sprite = PresetFaces[(int)emotion];
        }

        public void ChangeCloth(int index)
        {
            Cloth.color = PresetClothColors[(int)index];
        }
        public void ChangeSkin(int index)
        {
            Cloth.color = PresetClothColors[(int)index];
        }
        public void ChangeShoes(int index)
        {
            Cloth.color = PresetClothColors[(int)index];
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



