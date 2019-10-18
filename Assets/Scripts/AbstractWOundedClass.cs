using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class AbstractWoundedClass
{
    enum WoundType
    {
        Minor,
        Major,
        Critical
    };

    protected string Name;
    protected string Age;
    protected string Rank;
    protected string Nationality;
    protected int WoundsMinor;
    protected int WoundsMajor;
    protected int WoundsCrit;

    private int DeathChance;

    public AbstractWoundedClass(string WoundedData = "")
    {
        string[] WoundedDataElements = AbstractStringBreaker.StringBreak(WoundedData);

        Name = WoundedDataElements[0];
        Age = WoundedDataElements[1];
        Rank = WoundedDataElements[2];
        Nationality = WoundedDataElements[3];
    }

    public int EditWounds(WoundType TypeOfWound, int WoundsNum)
    {
        if(TypeOfWound == Minor)
        {
            WoundsMinor += WoundsNum;
        } else if(TypeOfWound == Major)
        {
            WoundsMinor += WoundsNum;
        } else
        {
            WoundsCrit += WoundsNum;
        }
        
    }
}