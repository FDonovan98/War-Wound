using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSupplies
{
    public enum WoundType
    {
        Minor,
        Major,
        Critical
    };

    protected int[] Count = {0, 0, 0};

    public void SetCount(int Minor, int Major, int Critical)
    {
        if(Minor > 0)
        {
            Count[(int)WoundType.Minor] = Minor;
        } else
        {
            Count[(int)WoundType.Minor] = 0;
        }

        if (Major > 0)
        {
            Count[(int)WoundType.Major] = Major;
        } else
        {
            Count[(int)WoundType.Major] = 0;
        }

        if (Critical > 0)
        {
            Count[(int)WoundType.Critical] = Critical;
        } else
        {
            Count[(int)WoundType.Critical] = 0;
        }
    }

    public void EditCount(WoundType Type, int Change)
    {
        if((Count[(int)Type] += Change) > 0)
        {
            Count[(int)Type] += Change;
        } else
        {
            Count[(int)Type] = 0;
        }
            
    }
}
