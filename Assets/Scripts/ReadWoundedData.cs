using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public class ReadWoundedData : MonoBehaviour
{
    public AbstractWoundedClass[] wounded;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset woundedNamesAsset = Resources.Load<TextAsset>("Text Files/WoundedNames");
        Debug.Assert(woundedNamesAsset != null, "WoundedNames.txt could not be loaded");

        StringReader woundedNamesReader = new StringReader(woundedNamesAsset.text);

        int lineCount = 0;
        while (woundedNamesReader.ReadLine() != null)
        {
            lineCount++;
        }
        
        wounded = new AbstractWoundedClass[lineCount];
        woundedNamesReader = new StringReader(woundedNamesAsset.text);

        for(int i = 0; i < lineCount; i++)
        {
            wounded[i] = new AbstractWoundedClass(woundedNamesReader.ReadLine());
        }

        Debug.Log(wounded[0].Name);
        Debug.Log(wounded[1].Name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
