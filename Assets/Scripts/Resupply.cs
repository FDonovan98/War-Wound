using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resupply : AbstractSupplies
{
    public int[] DoResupply(int[] AvailableSupplies)
    {
        for(int i = 0; i < 3; i++)
        {
            AvailableSupplies[i] += Count[i];
        }

        return AvailableSupplies;
    }
}