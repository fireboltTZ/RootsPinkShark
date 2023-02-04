#if UNITY_EDITOR
using System;
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
    private string newname = "";
    private NameGenerator namegen;

    private void Awake()
    {
        namegen = NameGenerator.Instance;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Label(newname);

        if (GUILayout.Button("随机一个不带遗传的"))
        {
            newname = namegen.GenerateName(true);
        }

        if (GUILayout.Button("随机一个初代"))
        {
            newname = namegen.GenerateFirstGeneration(true);
        }

        if (GUILayout.Button("初代生子"))
        {
            newname = namegen.GenerateChild(true);
        }
    }
}

#endif