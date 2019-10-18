using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resupply
{
    public enum WoundType
    {
        Minor,
        Major,
        Critical
    };

    private int[] ResupplyCount = [0, 0, 0];

    public Resupply(int MinorResupply, int MajorResupply, int CriticalResupply)
    {
        ResupplyCount[(int)WoundType.Minor] = MinorResupply;
        ResupplyCount[(int)WoundType.Major] = MajorResupply;
        ResupplyCount[(int)WoundType.Critical] = CriticalResupply;
    }

    public void EditResupplyAmount(WoundType SupplyType, int ChangeInResupply)
    {
        ResupplyCount[(int)SupplyType] += ChangeInResupply;
    }

    public int[] DoResupply(int[] AvailableSupplies)
    {
        for(int i = 0; i < 3; i++)
        {
            AvailableSupplies[i] += ResupplyCount[i];
        }

        return AvailableSupplies;
    }
}