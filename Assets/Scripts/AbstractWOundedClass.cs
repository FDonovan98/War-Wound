using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class AbstractWoundedClass : AbstractSupplies
{
    protected string Name;
    protected string Age;
    protected string Rank;
    protected string Nationality;

    protected int DeathChance;

    public AbstractWoundedClass(string WoundedData = "")
    {
        string[] WoundedDataElements = AbstractStringBreaker.StringBreak(WoundedData);

        Name = WoundedDataElements[0];
        Age = WoundedDataElements[1];
        Rank = WoundedDataElements[2];
        Nationality = WoundedDataElements[3];
    }
        
}