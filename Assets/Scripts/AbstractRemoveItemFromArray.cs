using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class AbstractRemoveItemFromArray
{
    public static object[] RemoveItem(object[] TargetArray, int ElementPosition)
    {
        if (ElementPosition != TargetArray.Length - 1)
        {
            for (int j = 0; j < TargetArray.Length - 1; j++)
            {
                TargetArray[ElementPosition] = TargetArray[ElementPosition + 1];
            }
        } else
        {
            Array.Resize(ref TargetArray, TargetArray.Length - 1);
        }

        return TargetArray;
    }

    public static int[] RemoveItem(int[] TargetArray, int ElementPosition)
    {
        if (ElementPosition != TargetArray.Length - 1)
        {
            for (int j = 0; j < TargetArray.Length - 1; j++)
            {
                TargetArray[ElementPosition] = TargetArray[ElementPosition + 1];
            }
        } else
        {
            Array.Resize(ref TargetArray, TargetArray.Length - 1);
        }

        return TargetArray;
    }
}
