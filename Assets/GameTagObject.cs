using System.Collections;
using System.Collections.Generic;

using cfg;
using TMPro;
using UnityEngine;

using ModelShark;
public class GameTagObject : MonoBehaviour
{
    private GameTag GameTag;
    public TextMeshProUGUI text;
    public TooltipTrigger TooltipTrigger => this.GetComponent<TooltipTrigger>();

    public void Init(GameTag gameTag)
    {
        GameTag = gameTag;
        text.text = gameTag.TagName;
        TooltipTrigger.SetText("Title", gameTag.TagName);
        TooltipTrigger.SetText("BodyText", gameTag.Desc);

    }
}
