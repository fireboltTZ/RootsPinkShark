using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class NameObject : ScriptableObject
{
    public List<string> LastName = new List<string>();
    public List<string> MFirstName = new List<string>();
    public List<string> FFirstName = new List<string>();

#if UNITY_EDITOR
    [MenuItem("NameGenerator/CreateNameObject")]
    public static void GenerateNameObject()
    {
        NameObject nameObject = ScriptableObject.CreateInstance<NameObject>();
        Debug.Log("Creating so at " + Application.dataPath);
        string path = "Assets/name.asset";
        AssetDatabase.CreateAsset(nameObject, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = nameObject;
    }

#endif
}