using cfg;
using MatchThree.System;
using QFramework;
using Roots;
using Roots.Event;
using Roots.Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventOptionButton : MonoBehaviour, ICanGetSystem, ICanSendEvent
{
    private Button button;
    private EventOption eventOption;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (EventOptionAvailable())
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void EventOptionInit(int index)
    {
        eventOption = this.GetSystem<GameSystem>().Table.TbEventOption[index];
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = eventOption.EventOptionDesc;
        button.onClick.AddListener(OptionEffect);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OptionEffect);
    }


    private bool EventOptionAvailable()
    {
        if(eventOption.AttrLimit == null || eventOption.AttrLimit.Count == 0)
        {
            return true;
        }
        bool available = true;
        Character main = this.GetSystem<GameSystem>().MainCharacter;
        for (int i = 0; i < eventOption.AttrLimit.Count; i++)
        {
            available &= EventExecutor.Instance.ConditionAvailable(main, eventOption.AttrLimit[i]);
        }
        return available;
    }

    private void OptionEffect()
    {
        this.SendEvent<TimeContinueEvent>();
        UIKit.ClosePanel<UIOptionPanel>();
        if(eventOption.OptionWinEffect == null || eventOption.OptionWinEffect.Count == 0)
        {
            return;
        }
        Character main = this.GetSystem<GameSystem>().MainCharacter;
        ResourceExecutor.Instance.EffectExecute(main, eventOption.OptionWinEffect);
        this.SendEvent(new NormalGameLogEvent() { content = eventOption.OptionDES });
    }



    public IArchitecture GetArchitecture()
    {
        return Roots.Roots.Interface;
    }
}
