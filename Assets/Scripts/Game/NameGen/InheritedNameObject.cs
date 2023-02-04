using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class InheritedNameObject : ScriptableObject
{
    public List<string> Xing = new List<string>();
    public List<string> Bei = new List<string>();
    public List<string> Ming = new List<string>();
    public List<string> NvMing = new List<string>();
    public List<string> Hao = new List<string>();

#if UNITY_EDITOR
    [MenuItem("NameGenerator/CreateInheriteNameObject")]
    public static void GenerateNameObject()
    {
        InheritedNameObject nameObject = ScriptableObject.CreateInstance<InheritedNameObject>();
        Debug.Log("Creating so at " + Application.dataPath);
        string path = "Assets/InheritedNameObject.asset";
        AssetDatabase.CreateAsset(nameObject, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = nameObject;
    }

#endif
}