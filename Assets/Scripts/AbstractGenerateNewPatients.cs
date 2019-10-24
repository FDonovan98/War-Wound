using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGenerateNewPatients
{
    private static readonly int[] WoundWeighting = {1, 2, 4};

    //PlaceHolder script
    private static int[] CalculateNumberOfWounds(float Severity, int[] WoundWeighting)
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

            } else
            {
                NumberOfWounds[0] += 1;
                Severity -= WoundWeighting[0];
            }

        } while (Severity > 0);

        return NumberOfWounds;
    }

    public static AbstractWoundedClass[] GenerateNewPatients(int CurrentWeightedDeathScore, int MaxPatients, ref AbstractWoundedClass[] Wounded, out List<int> NewPatientList)
    {
        int SpawnValue = Random.Range(CurrentWeightedDeathScore / 2, CurrentWeightedDeathScore);
        int NumberOfPatients = SpawnValue % MaxPatients;

        if(NumberOfPatients == 0)
        {
            NumberOfPatients = 1;
        }

        //Place holder
        //float Severity = SpawnValue * (MaxPatients / NumberOfPatients);
        float Severity = SpawnValue / NumberOfPatients;

        int i = 0;
        NewPatientList = new List<int>();

        do
        {
            if (!Wounded[i].Injured)
            {
                NewPatientList.Add(i);
            }

            i++;

        } while (i < Wounded.Length && NewPatientList.Count < NumberOfPatients);

        for (i = 0; i < NewPatientList.Count; i++)
        {
            int[] NumberOfWounds = CalculateNumberOfWounds(Severity, WoundWeighting);

            for (i = 0; i < NumberOfPatients; i++)
            {
                for (int j = 0; j < AbstractSupplies.NumberOfWoundTypes; j++)
                {
                    Wounded[NewPatientList[i]].EditCount((AbstractSupplies.WoundType)j, NumberOfWounds[j]);
                    Wounded[NewPatientList[i]].Injured = true;
                }
            }
        }

        return Wounded;
    }
}
