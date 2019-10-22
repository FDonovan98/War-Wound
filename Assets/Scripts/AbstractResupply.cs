using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractResupply : AbstractSupplies
{
    public static AbstractSupplies DoResupply(AbstractSupplies AvailableSupplies, AbstractSupplies Resupply)
    {
        for(int i = 0; i < NumberOfWoundTypes; i++)
        {
            AvailableSupplies.EditCount((WoundType)i, Resupply.Count[i]);
        }
        return AvailableSupplies;
    }
}