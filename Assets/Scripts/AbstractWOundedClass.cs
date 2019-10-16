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

    public AbstractWoundedClass(string AllData = "", char Seperator = ',')
    {
        if(AllData != "")
        {
            string[] items = AllData.Split(Seperator);

            Name = items[0];
            Age = items[1];
            Rank = items[2];
            Nationality = items[3];
        }
        
    }
}