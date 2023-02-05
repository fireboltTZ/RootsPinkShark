using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using cfg;
using DG.Tweening;
using MatchThree.System;
using QFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ModelShark;
using Roots;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameItem : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler, ICanGetSystem, IPointerDownHandler
{
    // Start is called before the first frame update
    public Image ItemImage;
    public TooltipTrigger TooltipTrigger => GetComponent<TooltipTrigger>();
    private ResLoader _resLoader = ResLoader.Allocate();
    private GameResource gameResource;
    public void Init(cfg.GameResource resource)
    {
        gameResource = resource;
        if (resource.IsUsable)
        {
            GetComponent<Shadow>().enabled = true;
        }
        if(resource.ResourceImage != "")
            ItemImage.sprite = _resLoader.LoadSync<Sprite>(resource.ResourceImage);
        TooltipTrigger.SetText("Title", resource.Name);
        TooltipTrigger.SetText("BodyText",resource.Desc);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameResource.IsUsable || UIKit.GetPanel<UIOptionPanel>()!=null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), Input.mousePosition, UIKit.Root.Camera, out Vector2 localPoint);
            transform.position = transform.TransformPoint(localPoint);
            
        }
        else
        {
            transform.DOShakePosition(0.1f);
        }
        
    }
    

    private Vector2 OriginalPos;
    private Transform OriginalParentTransform;
    public void OnBeginDrag(PointerEventData eventData)
    {
        OriginalPos = GetComponent<RectTransform>().position;
        OriginalParentTransform = transform.parent;
        transform.parent = OriginalParentTransform.parent.parent.parent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {


        GetComponent<RectTransform>().position = OriginalPos;
        transform.parent = OriginalParentTransform;
    }

    public IArchitecture GetArchitecture()
    {
        return Roots.Roots.Interface;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.clickCount == 2) {
            this.GetSystem<GameSystem>().MainCharacter.UseResource(gameResource);
        }
    }
}
