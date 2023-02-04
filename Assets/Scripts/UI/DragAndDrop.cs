using MatchThree.System;
using QFramework;
using Roots;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, ICanGetSystem, ICanRegisterEvent
{
    public IArchitecture GetArchitecture()
    {
        return Roots.Roots.Interface;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //this.RegisterEvent<>
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //UIKit.GetPanel<UIGamePanel>().addItem//
        //this.GetSystem<GameSystem>().EndGame();
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

}
