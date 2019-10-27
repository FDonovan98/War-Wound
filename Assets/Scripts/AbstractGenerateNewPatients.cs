using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGenerateNewPatients
{
    private static readonly int[] WoundWeighting = {1, 2, 4};

    //PlaceHolder script. Equation for generating wounds based on severity needs to be improved so it's less consistent
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

    //Reads in the players CurrentWeightedDeathScore and outputs a list of wounded. The higher this score is the more severely/ more numerous wounded are created
    public static AbstractWoundedClass[] GenerateNewPatients(int CurrentWeightedDeathScore, int MaxPatients, ref AbstractWoundedClass[] Wounded, out List<int> NewPatientList)
    {
        //Random used to give some varience between days even with a constant CurrentWeightedDeathScore
        int SpawnValue = Random.Range(CurrentWeightedDeathScore / 2, CurrentWeightedDeathScore);
        int NumberOfPatients = SpawnValue % MaxPatients;

        if(NumberOfPatients == 0)
        {
            NumberOfPatients = 1;
        }

        //Place holder - severity equation may be changed
        //float Severity = SpawnValue * (MaxPatients / NumberOfPatients);
        float Severity = SpawnValue / NumberOfPatients;

        int i = 0;
        NewPatientList = new List<int>();

        //Grabs the first n possible patients who aren't already wounded or being cared for
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
