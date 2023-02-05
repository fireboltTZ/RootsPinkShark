using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Random = UnityEngine.Random;

public class NameGenerator : MonoSingleton<NameGenerator>
{
    private NameObject nameObject;
    private InheritedNameObject inheritedNameObject;
    private bool noNameLoaded = false;
    private bool noInheritedNameLoaded = false;
    private List<string> lastName = new List<string>(){"赵","钱","孙","张","马","贺","司马","令狐","紫","陶"};
    private List<string> mFirstName = new List<string>(){"亦飞","豪景","而立","文举","文韬","明海","北海","药羽","盛楠","陶","武"};

    private List<string> fFirstName = new List<string>(){"灵","巧","敏","蕊","熏儿","超群","听白","含雪"};

// Inherited name
    private List<string> Xing = new List<string>();
    private List<string> Bei = new List<string>();
    private List<string> Ming = new List<string>();
    private List<string> NvMing = new List<string>();
    
    private List<string> Hao = new List<string>();

    
    
    private int indexXing = -1;
    private int indexBei = -1;

    private int indexHao = -1;

    public override void OnSingletonInit()
    {
        base.OnSingletonInit();
        nameObject = Resources.Load<NameObject>("name");
        if (nameObject == null)
        {
            Debug.LogError("null exp");
            return;
        }

        inheritedNameObject = Resources.Load<InheritedNameObject>("InheritedNameObject");        
        
        if (inheritedNameObject == null)
        {
            Debug.LogError("null exp");
            return;
        }

        //ImportNames();
        //ImportInheritedName();
    }

    private void ImportNames()
    {
        lastName = nameObject.LastName;
        mFirstName = nameObject.MFirstName;
        fFirstName = nameObject.FFirstName;
        if (lastName.Count == 0 || mFirstName.Count == 0 || fFirstName.Count == 0)
        {
            noNameLoaded = true;
        }
    }

    private void ImportInheritedName()
    {
        Xing = inheritedNameObject.Xing;
        Bei = inheritedNameObject.Bei;
        Ming = inheritedNameObject.Ming;
        NvMing = inheritedNameObject.NvMing;
        if (Xing.Count == 0 || Bei.Count == 0 || Ming.Count == 0 || Hao.Count == 0)
        {
            noInheritedNameLoaded = true;
        }
    }

    private string XING;
    public string GenerateName(bool isMale)
    {


        List<string> firstNames;
        if (isMale)
        {
            firstNames = mFirstName;
        }

        firstNames = fFirstName;
        string generateName = "";
        int indexLastName = Random.Range(0, lastName.Count);
        int indexFirstName = Random.Range(0, firstNames.Count);

        generateName = lastName[indexLastName] + firstNames[indexFirstName];
        XING = lastName[indexLastName];
        return generateName;
    }

    public string GenerateFirstGeneration(bool isMale)
    {
        string firstGeneration = "";

 

        indexXing = Random.Range(0, Xing.Count);
        indexBei = Random.Range(0, Bei.Count);
        if (!isMale)
        {
            var indexNvMing = Random.Range(0, NvMing.Count);
            firstGeneration = Xing[indexXing] + Bei[indexBei] + NvMing[indexNvMing];
            return firstGeneration;
        }
        var indexMing = Random.Range(0, Ming.Count);

        firstGeneration = Xing[indexXing] + Bei[indexBei] + Ming[indexMing];

        return firstGeneration;
    }

    public string GenerateChild(bool isMale)
    {

        List<string> firstNames;
        if (isMale)
        {
            firstNames = mFirstName;
        }

        firstNames = fFirstName;
        int indexFirstName = Random.Range(0, firstNames.Count);
        return XING + firstNames[indexFirstName];
    }
    
    public List<string> GenerateChild(List<bool> isMale)
    {
        if (indexXing == -1)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < isMale.Count; i++)
            {
                names.Add("狗蛋二");
            }

            return names;
        }

        List<string> childGeneration = new List<string>();
        
        indexBei = Random.Range(0, Bei.Count);
        var indexMing = Random.Range(0, Ming.Count);

        for (int i = 0; i < isMale.Count; i++)
        {
            if (isMale[i] == false)
            {
                indexMing = Random.Range(0, NvMing.Count);
                string nvchildname = Xing[indexXing] + Bei[indexBei] + NvMing[indexMing];
                childGeneration.Add(nvchildname);
                continue;
            }
            string childname = Xing[indexXing] + Bei[indexBei] + Ming[indexMing];
            childGeneration.Add(childname);
        }
        
        return childGeneration;
    }
}