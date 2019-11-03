using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGenerateNewPatients
{
    private static readonly int[] woundWeighting = { 1, 2, 4 };

    //PlaceHolder script. Equation for generating wounds based on severity needs to be improved so it's less consistent
    private static int[] CalculateNumberOfWounds(float severity, int[] woundWeighting)
    {
        int[] numberOfWounds = { 0, 0, 0 };

        do
        {
            if (severity >= woundWeighting[2])
            {
                numberOfWounds[2] += 1;
                severity -= woundWeighting[2];

            }
            else if (severity >= woundWeighting[1])
            {
                numberOfWounds[1] += 1;
                severity -= woundWeighting[1];

            }
            else
            {
                numberOfWounds[0] += 1;
                severity -= woundWeighting[0];
            }

        } while (severity > 0);

        return numberOfWounds;
    }

    //Reads in the players CurrentWeightedDeathScore and outputs a list of wounded. The higher this score is the more severely/ more numerous wounded are created
    public static AbstractWoundedClass[] GenerateNewPatients(int CurrentWeightedDeathScore, int MaxPatients, ref AbstractWoundedClass[] Wounded, out List<int> NewPatientList)
    {
        //Random used to give some varience between days even with a constant CurrentWeightedDeathScore
        int SpawnValue = Random.Range(CurrentWeightedDeathScore / 2, CurrentWeightedDeathScore);
        int NumberOfPatients = SpawnValue % MaxPatients;

        if (NumberOfPatients == 0)
        {
            NumberOfPatients = 1;
        }

        //Place holder - severity equation may be changed
        //float severity = SpawnValue * (MaxPatients / NumberOfPatients);
        float severity = SpawnValue / NumberOfPatients;

        int i = 0;
        NewPatientList = new List<int>();

        //Grabs the first n possible patients who aren't already wounded or being cared for
        do
        {
            if (!Wounded[i].injured)
            {
                NewPatientList.Add(i);
            }

            i++;

        } while (i < Wounded.Length && NewPatientList.Count < NumberOfPatients);

        for (i = 0; i < NewPatientList.Count; i++)
        {
            int[] numberOfWounds = CalculateNumberOfWounds(severity, woundWeighting);

            for (i = 0; i < NumberOfPatients; i++)
            {
                for (int j = 0; j < AbstractSupplies.numberOfWoundTypes; j++)
                {
                    Wounded[NewPatientList[i]].EditCount((AbstractSupplies.WoundType)j, numberOfWounds[j]);
                    Wounded[NewPatientList[i]].injured = true;
                }
            }
        }

        return Wounded;
    }
}
