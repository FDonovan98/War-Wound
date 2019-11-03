using UnityEngine;

public class AbstractWoundedClass : AbstractSupplies
{
    internal string name;
    internal int age;
    internal AvailableRanks rank;
    internal string nationality;

    private int deathChanceModifier = 0;
    internal int totalDeathChance = 0;
    internal bool dead = false;

    public bool injured = false;

    private int insufficientMedTreatmentChange = 40;

    private int[] woundDeathChance = {10, 20, 40};

    public bool hasBed;
    private int lengthOfBedStay = 0;
    private int bedModifier = 0;

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
    public AbstractWoundedClass(string woundedData = "")
    {
        string[] WoundedDataElements = AbstractStringBreaker.StringBreak(woundedData);

        name = WoundedDataElements[0];
        nationality = WoundedDataElements[1];

        age = Random.Range(16, 65);

        //Generates a random rank using an exponential curve, so higher ranks are rarer 
        //Follows curve x = 10^(y-1), 0 <= x <= 10)
        float rankValueFloat = Random.Range(0.0f, 2.0f);
        rankValueFloat = Mathf.Pow(10, rankValueFloat - 1);
        int rankValueInt = (int)Mathf.Floor(rankValueFloat);
        rank = (AvailableRanks)rankValueInt;
    }

    private bool CheckIfInjured()
    {
        if(count[0] == 0)
        {
            for(int i = 1; i < count.Length; i++)
            {
                if(count[i] != count[0])
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }

    public void TreatWound(WoundType wound, WoundType medicine)
    {
        int treatmentDifference = (int)medicine - (int)wound;

        if(treatmentDifference < 0)
        {
            if(treatmentDifference == -1)
            {
                if(UnityEngine.Random.Range(0, 100) <= insufficientMedTreatmentChange)
                {
                    EditCount(wound, -1);
                }
            } else
            {
                if (UnityEngine.Random.Range(0, 100) <= insufficientMedTreatmentChange / 2)
                {
                    EditCount(wound, -1);
                }
            }
        }
        if(treatmentDifference >= 0)
        {
            EditCount(wound, -1);
        }

        injured = CheckIfInjured();
        CalculateTotalDeathChance();
    }

    public void CalculateTotalDeathChance()
    {
        totalDeathChance = 0;

        for(int i = 0; i < numberOfWoundTypes; i++)
        {
            totalDeathChance += count[i] * woundDeathChance[i];
        }

        totalDeathChance = OnlyAllowPositive(totalDeathChance, deathChanceModifier);
    }

    public void CheckIfKilled()
    {
        if(Random.Range(0, 100) <= totalDeathChance)
        {
            dead = true;
        }
    }

    public void GiveBed(int lengthOfStay)
    {
        hasBed = true;
        lengthOfBedStay = lengthOfStay;
        deathChanceModifier -= lengthOfBedStay * bedModifier;
    }

    public void EditLengthOfStay(int change)
    {
        if (hasBed)
        {
            lengthOfBedStay = OnlyAllowPositive(lengthOfBedStay, change);
        }
        
        if(lengthOfBedStay == 0)
        {
            hasBed = false;
            CheckIfKilled();

            if (!dead)
            {
                int[] NoWounds = { 0, 0, 0 };
                SetCount(NoWounds);
            }
        }

    }        
}