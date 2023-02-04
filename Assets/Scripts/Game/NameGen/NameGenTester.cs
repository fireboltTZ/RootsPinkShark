#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NameGenTester : MonoBehaviour
{
}

[CustomEditor(typeof(NameGenTester))]
public class testEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("test"))
        {
            var namegen = NameGenerator.Instance;
            var nam = namegen.GenerateName(true);
            Debug.Log(nam);
        }
    }
}

#endif