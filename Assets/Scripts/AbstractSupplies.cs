using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbstractSupplies : AbstractOnlyAllowPositiveResult
{
    public enum WoundType
    {
        Minor,
        Major,
        Critical
    };

    public int NumberOfWoundTypes = Enum.GetNames(typeof(WoundType)).Length;

    protected int[] Count = {0, 0, 0};

    public void SetCount(int[] TypeCount)
    {
        for(int i = 0; i < NumberOfWoundTypes; i++)
        {
            Count[i] = OnlyAllowPositive(TypeCount[i], 0);
        }
    }

    public void EditCount(WoundType Type, int Change)
    {
        Count[(int)Type] = OnlyAllowPositive(Count[(int)Type], Change);
            
    }
}
