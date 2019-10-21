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

    private int DeathChanceModifier = 0;
    internal int TotalDeathChance = 0;
    internal bool Dead = false;

    private int InsufficientMedTreatmentChange = 40;

    private int[] WoundDeathChance = {10, 20, 40};

    public bool HasBed;
    private int LengthOfBedStay = 0;
    private int BedModifier = 0;

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

        CalculateTotalDeathChance();
    }

    public void CalculateTotalDeathChance()
    {
        TotalDeathChance = 0;

        for(int i = 0; i < NumberOfWoundTypes; i++)
        {
            TotalDeathChance += Count[i] * WoundDeathChance[i];
        }

        TotalDeathChance = OnlyAllowPositive(TotalDeathChance, DeathChanceModifier);
    }

    public void CheckIfKilled()
    {
        if(UnityEngine.Random.Range(0, 100) <= TotalDeathChance)
        {
            Dead = true;
        }
    }

    public void GiveBed(int LengthOfStay)
    {
        HasBed = true;
        LengthOfBedStay = LengthOfStay;
        DeathChanceModifier -= LengthOfBedStay * BedModifier;
    }

    public void EditLengthOfStay(int Change)
    {
        if (HasBed)
        {
            LengthOfBedStay = OnlyAllowPositive(LengthOfBedStay, Change);
        }
        
        if(LengthOfBedStay == 0)
        {
            HasBed = false;
            CheckIfKilled();

            if (!Dead)
            {
                int[] NoWounds = { 0, 0, 0 };
                SetCount(NoWounds);
            }
        }

    }        
}