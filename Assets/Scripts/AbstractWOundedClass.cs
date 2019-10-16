using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class AbstractWoundedClass
{
    public string Name;
    public string Age;
    public string Rank;
    public string Nationality;

    public AbstractWoundedClass(string WoundedData = "")
    {
        string[] WoundedDataElements = AbstractStringBreaker.StringBreak(WoundedData);

        Name = WoundedDataElements[0];
        Age = WoundedDataElements[1];
        Rank = WoundedDataElements[2];
        Nationality = WoundedDataElements[3];
        
    }
}