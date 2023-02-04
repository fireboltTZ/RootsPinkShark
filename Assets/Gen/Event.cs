//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg
{ 

public sealed partial class Event :  Bright.Config.BeanBase 
{
    public Event(JSONNode _json) 
    {
        { if(!_json["EventName"].IsString) { throw new SerializationException(); }  EventName = _json["EventName"]; }
        { if(!_json["Desc"].IsString) { throw new SerializationException(); }  Desc = _json["Desc"]; }
        { if(!_json["EventType"].IsNumber) { throw new SerializationException(); }  EventType = (EventType)_json["EventType"].AsInt; }
        { if(!_json["EventId"].IsNumber) { throw new SerializationException(); }  EventId = _json["EventId"]; }
        { if(!_json["GroupId"].IsNumber) { throw new SerializationException(); }  GroupId = _json["GroupId"]; }
        { if(!_json["IsGenUnique"].IsBoolean) { throw new SerializationException(); }  IsGenUnique = _json["IsGenUnique"]; }
        { if(!_json["IsAllUnique"].IsBoolean) { throw new SerializationException(); }  IsAllUnique = _json["IsAllUnique"]; }
        { if(!_json["IsInteractive"].IsBoolean) { throw new SerializationException(); }  IsInteractive = _json["IsInteractive"]; }
        { var __json0 = _json["AppearCondition"]; if(!__json0.IsArray) { throw new SerializationException(); } AppearCondition = new System.Collections.Generic.List<EventCondition>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { EventCondition __v0;  { if(!__e0.IsObject) { throw new SerializationException(); }  __v0 = EventCondition.DeserializeEventCondition(__e0);  }  AppearCondition.Add(__v0); }   }
        { var __json0 = _json["Options"]; if(!__json0.IsArray) { throw new SerializationException(); } Options = new System.Collections.Generic.List<EventOption>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { EventOption __v0;  { if(!__e0.IsObject) { throw new SerializationException(); }  __v0 = EventOption.DeserializeEventOption(__e0);  }  Options.Add(__v0); }   }
        { var __json0 = _json["Effects"]; if(!__json0.IsArray) { throw new SerializationException(); } Effects = new System.Collections.Generic.List<EventEffect>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { EventEffect __v0;  { if(!__e0.IsObject) { throw new SerializationException(); }  __v0 = EventEffect.DeserializeEventEffect(__e0);  }  Effects.Add(__v0); }   }
        { if(!_json["IsOnBase"].IsBoolean) { throw new SerializationException(); }  IsOnBase = _json["IsOnBase"]; }
        PostInit();
    }

    public Event(string EventName, string Desc, EventType EventType, int EventId, int GroupId, bool IsGenUnique, bool IsAllUnique, bool IsInteractive, System.Collections.Generic.List<EventCondition> AppearCondition, System.Collections.Generic.List<EventOption> Options, System.Collections.Generic.List<EventEffect> Effects, bool IsOnBase ) 
    {
        this.EventName = EventName;
        this.Desc = Desc;
        this.EventType = EventType;
        this.EventId = EventId;
        this.GroupId = GroupId;
        this.IsGenUnique = IsGenUnique;
        this.IsAllUnique = IsAllUnique;
        this.IsInteractive = IsInteractive;
        this.AppearCondition = AppearCondition;
        this.Options = Options;
        this.Effects = Effects;
        this.IsOnBase = IsOnBase;
        PostInit();
    }

    public static Event DeserializeEvent(JSONNode _json)
    {
        return new Event(_json);
    }

    /// <summary>
    /// 事件名称
    /// </summary>
    public string EventName { get; private set; }
    /// <summary>
    /// 事件描述
    /// </summary>
    public string Desc { get; private set; }
    /// <summary>
    /// 事件类型
    /// </summary>
    public EventType EventType { get; private set; }
    /// <summary>
    /// 事件ID
    /// </summary>
    public int EventId { get; private set; }
    /// <summary>
    /// 所属事件组ID
    /// </summary>
    public int GroupId { get; private set; }
    /// <summary>
    /// 是否此代唯一
    /// </summary>
    public bool IsGenUnique { get; private set; }
    /// <summary>
    /// 是否历史唯一
    /// </summary>
    public bool IsAllUnique { get; private set; }
    /// <summary>
    /// 是否是可交互事件
    /// </summary>
    public bool IsInteractive { get; private set; }
    /// <summary>
    /// 出现条件
    /// </summary>
    public System.Collections.Generic.List<EventCondition> AppearCondition { get; private set; }
    /// <summary>
    /// 事件选项
    /// </summary>
    public System.Collections.Generic.List<EventOption> Options { get; private set; }
    /// <summary>
    /// 事件结果（非交互事件才需要）
    /// </summary>
    public System.Collections.Generic.List<EventEffect> Effects { get; private set; }
    /// <summary>
    /// 是否在初始事件库
    /// </summary>
    public bool IsOnBase { get; private set; }

    public const int __ID__ = 67338874;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var _e in AppearCondition) { _e?.Resolve(_tables); }
        foreach(var _e in Options) { _e?.Resolve(_tables); }
        foreach(var _e in Effects) { _e?.Resolve(_tables); }
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var _e in AppearCondition) { _e?.TranslateText(translator); }
        foreach(var _e in Options) { _e?.TranslateText(translator); }
        foreach(var _e in Effects) { _e?.TranslateText(translator); }
    }

    public override string ToString()
    {
        return "{ "
        + "EventName:" + EventName + ","
        + "Desc:" + Desc + ","
        + "EventType:" + EventType + ","
        + "EventId:" + EventId + ","
        + "GroupId:" + GroupId + ","
        + "IsGenUnique:" + IsGenUnique + ","
        + "IsAllUnique:" + IsAllUnique + ","
        + "IsInteractive:" + IsInteractive + ","
        + "AppearCondition:" + Bright.Common.StringUtil.CollectionToString(AppearCondition) + ","
        + "Options:" + Bright.Common.StringUtil.CollectionToString(Options) + ","
        + "Effects:" + Bright.Common.StringUtil.CollectionToString(Effects) + ","
        + "IsOnBase:" + IsOnBase + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
