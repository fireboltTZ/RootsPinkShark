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

public class GameItem : MonoBehaviour, ICanGetSystem, IPointerDownHandler
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
        if(gameResource.ResourceId >= 43)
            ItemImage.sprite= _resLoader.LoadSync<Sprite>("resource_" + 42);
        else
        {
            ItemImage.sprite = _resLoader.LoadSync<Sprite>("resource_" + gameResource.ResourceId);
        }
        
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
    

    public IArchitecture GetArchitecture()
    {
        return Roots.Roots.Interface;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.clickCount == 1 && UIKit.GetPanel<UIOptionPanel>() != null)
        {
            UIKit.GetPanel<UIOptionPanel>().TryPutStaff(gameResource);

        }
        if (eventData.clickCount == 2) {
            this.GetSystem<GameSystem>().MainCharacter.UseResource(gameResource);
        }
    }
}
