using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Roots.Game;
using QFramework;
using System;
using TMPro;
using TreeEditor;

namespace Roots
{
    public class UINameCard : MonoBehaviour, ICanRegisterEvent, ICanGetSystem
    {
        public Character Person;
        public Button nameCardButton;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI descriptionText;
        
        public IArchitecture GetArchitecture()
        {
            return Roots.Interface;
        }


        // Start is called before the first frame update
        void Start()
        {
            nameCardButton.onClick.AddListener(() => SelectCard());
        }

        public void SelectCard()
        {
            UIKit.GetPanel<UIRootPanel>().SetSelectedCharacter(Person);
        }

        public void SetUpPerson(Character person)
        {
            Person = person;
            nameText.text = person.Name;
            descriptionText.text = person.Name;
        }
    }

}
