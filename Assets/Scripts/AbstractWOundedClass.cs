using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class AbstractWoundedClass : AbstractSupplies
{
    internal string Name;
    internal string Age;
    internal string Rank;
    internal string Nationality;

    internal int DeathChance = 0;

    internal int InsufficientMedTreatmentChange = 40;

    public AbstractWoundedClass(string WoundedData = "")
    {
        string[] WoundedDataElements = AbstractStringBreaker.StringBreak(WoundedData);

        Name = WoundedDataElements[0];
        Age = WoundedDataElements[1];
        Rank = WoundedDataElements[2];
        Nationality = WoundedDataElements[3];
    }

    public void TreatWound(WoundType Wound, WoundType Medicine)
    {
        int TreatmentDifference = (int)Medicine - (int)Wound;

        if(TreatmentDifference < 0)
        {
            if(TreatmentDifference == -1)
            {
                if(UnityEngine.Random.Range(0, 100) <= InsufficientMedTreatmentChange)
                {
                    EditCount(Wound, -1);
                }
            } else
            {
                if (UnityEngine.Random.Range(0, 100) <= InsufficientMedTreatmentChange / 2)
                {
                    EditCount(Wound, -1);
                }
            }
        }
        if(TreatmentDifference >= 0)
        {
            EditCount(Wound, -1);
        }
    }
        
}