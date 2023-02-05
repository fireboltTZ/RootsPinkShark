using System;
using System.Collections;
using System.Collections.Generic;
using cfg;
using MatchThree.System;
using QFramework;
using Roots.Event;
using Roots.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, ICanGetSystem,ICanSendEvent
{
    public cfg.ResourceType RequiredType;
    public Image Image;
    private GameResource GameResource = null;

    public bool IsFull => GameResource != null;
    private ResLoader _resLoader = ResLoader.Allocate();
    public void Fill(GameResource gameResource)
    {
        this.GetSystem<GameSystem>().MainCharacter.Resources.Remove(GameResource);
        this.SendEvent(new GetNewResourcesEvent(){Resources = this.GetSystem<GameSystem>().MainCharacter.Resources});
        GameResource = gameResource;
        if(gameResource.ResourceId >= 43)
            Image.sprite = _resLoader.LoadSync<Sprite>("resource_" + 42);
        else
        {
            Image.sprite = _resLoader.LoadSync<Sprite>("resource_" + gameResource.ResourceId);
        }

        if (gameResource.Effects.Count != 0)
        {
            ResourceExecutor.Instance.EffectExecute(this.GetSystem<GameSystem>().MainCharacter,gameResource.Effects);
        }
        
        Image.ColorAlpha(1);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameResource != null)
        {
            this.GetSystem<GameSystem>().MainCharacter.Resources.Add(GameResource);
            this.SendEvent(new GetNewResourcesEvent(){Resources = this.GetSystem<GameSystem>().MainCharacter.Resources});
            Image.sprite = null;
            Image.ColorAlpha(0);
        }
    }

    public IArchitecture GetArchitecture()
    {
        return Roots.Roots.Interface;
    }
}
