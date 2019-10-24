using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGenerateNewPatients
{
    private int[] WoundWeighting = {1, 2, 4};

    //PlaceHolder script
    private static int[] CalculateNumberOfWounds(int Severity)
    {
        int[] NumberOfWounds = {0, 0, 0};
        
        NumberOfWounds = new int[] {1, 1, 1};

        return NumberOfWounds;
    }

    public static AbstractWoundedClass[] GenerateNewPatients(int Seed, int MaxPatients, ref AbstractWoundedClass[] Wounded, out List<int> NewPatientList)
    {
        int SpawnValue = Random.Range(Seed / 2, Seed);
        int NumberOfPatients = SpawnValue % MaxPatients;
        int Severity = SpawnValue / MaxPatients;

        Severity *= 10;
        Severity /= NumberOfPatients;

        int i = 0;
        NewPatientList = new List<int>();

        //Could loop infinitely if the number of available wounded in the list is too small. Game should end before this
        do
        {
            if (!Wounded[i].Injured)
            {
                NewPatientList.Add(i);
            }

            i++;

        } while(i < Wounded.Length && NewPatientList.Count < NumberOfPatients);

        for(i = 0; i < NewPatientList.Count; i++)
        {
            int[] NumberOfWounds = CalculateNumberOfWounds(Severity);

            for(i = 0; i < AbstractSupplies.NumberOfWoundTypes; i++)
            {
                Wounded[NewPatientList[i]].EditCount((AbstractSupplies.WoundType)i, NumberOfWounds[i]);
            }
        }

        return Wounded;
    }
}
