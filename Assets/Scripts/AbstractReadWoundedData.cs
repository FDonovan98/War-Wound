using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public class AbstractReadWoundedData : MonoBehaviour
{
    private AbstractWoundedClass[] wounded;

    // Start is called before the first frame update
    public AbstractWoundedClass[] ReadInWounded()
    {
        AbstractGenerateStringReader.GenerateStringReader("WoundedNames", out StringReader woundedNamesReader, out int lineCount);
        
        wounded = new AbstractWoundedClass[lineCount];

        for(int i = 0; i < lineCount; i++)
        {
            wounded[i] = new AbstractWoundedClass(woundedNamesReader.ReadLine());
        }

        ///////////// Debug to print all names read in
        for (int i = 0; i < wounded.Length; i++)
        {
            Debug.Log(wounded[i].Name);
        }
        /////////////

        return wounded;

    }

}
