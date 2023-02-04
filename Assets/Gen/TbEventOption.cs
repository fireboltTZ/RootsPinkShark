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

public sealed partial class TbEventOption
{
    private readonly Dictionary<int, EventOption> _dataMap;
    private readonly List<EventOption> _dataList;
    
    public TbEventOption(JSONNode _json)
    {
        _dataMap = new Dictionary<int, EventOption>();
        _dataList = new List<EventOption>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = EventOption.DeserializeEventOption(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.EventOptionid, _v);
        }
        PostInit();
    }

    public Dictionary<int, EventOption> DataMap => _dataMap;
    public List<EventOption> DataList => _dataList;

    public EventOption GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public EventOption Get(int key) => _dataMap[key];
    public EventOption this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    
    partial void PostInit();
    partial void PostResolve();
}

}