using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public class StringBreaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextAsset woundedNamesAsset = Resources.Load<TextAsset>("Text Files/WoundedNames");
        Debug.Assert(woundedNamesAsset != null, "WoundedNames.txt could not be loaded");

        StringReader woundedNamesReader = new StringReader(woundedNamesAsset.text);

        List<string> woundedNames = new List<string>();
        int i = 0;
        while(woundedNamesReader.ReadLine() != null)
        {
            if j 
            int j = 0;
            woundedNames.Add(Convert.ToString(woundedNamesReader.Read()));
            if(woundedNamesReader.Peek() != ',')
            {
                if(j == 0)
                {
                    woundedNames[i] = woundedNames[i] + Convert.ToString(woundedNamesReader.Read());
                }
                
            } else
            {
                j += 1;
                woundedNamesReader.Read();
            }
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
