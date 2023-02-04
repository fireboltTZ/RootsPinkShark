using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using QFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameItem : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public Image ItemImage;
    private ResLoader _resLoader = ResLoader.Allocate();
    public void Init(cfg.GameResource resource)
    {
        if(resource.ResourceImage != "")
            ItemImage.sprite = _resLoader.LoadSync<Sprite>(resource.ResourceImage);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), Input.mousePosition, UIKit.Root.Camera, out Vector2 localPoint);
        transform.position = transform.TransformPoint(localPoint);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
