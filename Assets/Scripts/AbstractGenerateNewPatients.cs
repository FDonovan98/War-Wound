﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGenerateNewPatients
{
    private static readonly int[] WoundWeighting = {1, 2, 4};

    //PlaceHolder script
    private static int[] CalculateNumberOfWounds(int Severity, int[] WoundWeighting)
    {
        int[] NumberOfWounds = {0, 0, 0};

        do
        {
            if (Severity >= WoundWeighting[2])
            {
                NumberOfWounds[2] += 1;
                Severity -= WoundWeighting[2];
            } else if (Severity >= WoundWeighting[1])
            {
                NumberOfWounds[1] += 1;
                Severity -= WoundWeighting[1];
            } else if (Severity != 0)
            {
                NumberOfWounds[0] += 1;
                Severity -= WoundWeighting[0];
            }
        } while (Severity != 0);

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
            int[] NumberOfWounds = CalculateNumberOfWounds(Severity, WoundWeighting);

            for(i = 0; i < AbstractSupplies.NumberOfWoundTypes; i++)
            {
                Wounded[NewPatientList[i]].EditCount((AbstractSupplies.WoundType)i, NumberOfWounds[i]);
            }
        }

        return Wounded;
    }
}
