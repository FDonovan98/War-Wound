﻿using UnityEngine;

public class AbstractWoundedClass : AbstractSupplies
{
    internal string Name;
    internal int Age;
    internal AvailableRanks Rank;
    internal string Nationality;

    private int DeathChanceModifier = 0;
    internal int TotalDeathChance = 0;
    internal bool Dead = false;

    public bool Injured = false;

    private int InsufficientMedTreatmentChange = 40;

    private int[] WoundDeathChance = {10, 20, 40};

    public bool HasBed;
    private int LengthOfBedStay = 0;
    private int BedModifier = 0;

    public enum AvailableRanks
    {
        Private,
        Lance_Corporal,
        Lieutenant,
        Corporal,
        Sergeant,
        Staff_Sergeant,
        Captain,
        Warrant_Officer_2,
        Major,
        Warrant_Officer_1,
        Lietenant_Colonel
    }

    //Used with 'AbstractGenerateStringReader' script to generate variables using a text file to define name and nationality
    public AbstractWoundedClass(string WoundedData = "")
    {
        string[] WoundedDataElements = AbstractStringBreaker.StringBreak(WoundedData);

        Name = WoundedDataElements[0];
        Nationality = WoundedDataElements[1];

        Age = Random.Range(16, 65);

        //Generates a random rank using an exponential curve, so higher ranks are rarer 
        //Follows curve x = 10^(y-1), 0 <= x <= 10)
        float RankValueFloat = Random.Range(0.0f, 2.0f);
        RankValueFloat = Mathf.Pow(10, RankValueFloat - 1);
        int RankValueInt = (int)Mathf.Floor(RankValueFloat);
        Rank = (AvailableRanks)RankValueInt;
    }

    private bool CheckIfInjured()
    {
        if(Count[0] == 0)
        {
            for(int i = 1; i < Count.Length; i++)
            {
                if(Count[i] != Count[0])
                {
                    return true;
                }
            }
            return false;
        }
        return true;
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

        Injured = CheckIfInjured();
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
        if(Random.Range(0, 100) <= TotalDeathChance)
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