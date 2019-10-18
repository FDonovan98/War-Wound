using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class AbstractWoundedClass
{
    public enum WoundType
    {
        Minor,
        Major,
        Critical
    };

    protected string Name;
    protected string Age;
    protected string Rank;
    protected string Nationality;
    protected int WoundsMinor = 0;
    protected int WoundsMajor = 0;
    protected int WoundsCrit = 0;

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
        if(TypeOfWound == WoundType.Minor)
        {
            WoundsMinor += WoundsNum;
            if(WoundsMinor<0)
            {
                WoundsMinor = 0;
            }
        } else if(TypeOfWound == WoundType.Major)
        {
            WoundsMinor += WoundsNum;
            if (WoundsMajor < 0)
            {
                WoundsMajor = 0;
            }
        } else
        {
            WoundsCrit += WoundsNum;
            if (WoundsCrit < 0)
            {
                WoundsCrit = 0;
            }
        }
        
    }
}