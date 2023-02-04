using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Random = UnityEngine.Random;

public class NameGenerator : MonoSingleton<NameGenerator>
{
    public NameObject NameObject;
    private bool noNameLoaded;
    private List<string> lastName = new List<string>();
    private List<string> mFirstName = new List<string>();
    private List<string> fFirstName = new List<string>();

    public override void OnSingletonInit()
    {
        base.OnSingletonInit();
        NameObject = Resources.Load<NameObject>("name");
        if (NameObject == null)
        {
            Debug.LogError("null exp");
            return;
        }

        ImportNames();
    }

    private void ImportNames()
    {
        lastName = NameObject.LastName;
        mFirstName = NameObject.MFirstName;
        fFirstName = NameObject.FFirstName;
        if (lastName.Count == 0 || mFirstName.Count == 0 || fFirstName.Count == 0)
        {
            noNameLoaded = true;
        }
    }

    public string GenerateName(bool isMale)
    {
        if (!NameObject || noNameLoaded)
        {
            return "狗蛋儿";
        }

        List<string> firstNames;
        if (isMale)
        {
            firstNames = mFirstName;
        }

        firstNames = fFirstName;
        string name = "";
        int indexLastName = Random.Range(0, lastName.Count);
        int indexFirstName = Random.Range(0, firstNames.Count);

        name = lastName[indexLastName] + firstNames[indexFirstName];

        return name;
    }
}