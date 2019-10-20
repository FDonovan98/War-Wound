using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractOnlyAllowPositiveResult
{
    public int OnlyAllowPositive(int Value, int Change)
    {
        if ((Value += Change) > 0)
        {
           return Value + Change;
        } else
        {
            return 0;
        }
    }
}
