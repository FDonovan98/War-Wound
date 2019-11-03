using System;

public class AbstractSupplies : AbstractOnlyAllowPositiveResult
{
    public enum WoundType
    {
        Minor,
        Major,
        Critical
    };

    //Used elsewhere to improve robustnest to code if new WoundTypes are added
    public static int numberOfWoundTypes = Enum.GetNames(typeof(WoundType)).Length;

    //Stores how many {Minor, Major, Critical} this item has
    public int[] count = {0, 0, 0};

    public void SetCount(int[] typeCount)
    {
        for (int i = 0; i < numberOfWoundTypes; i++)
        {
            count[i] = OnlyAllowPositive(typeCount[i], 0);
        }
    }

    public void SetCount(int minorCount, int majorCount, int criticalCount)
    {
        count[(int)WoundType.Minor] = OnlyAllowPositive(minorCount, 0);
        count[(int)WoundType.Major] = OnlyAllowPositive(majorCount, 0);
        count[(int)WoundType.Critical] = OnlyAllowPositive(criticalCount, 0);
    }

    //Needed so class can be called without passing constructors
    public AbstractSupplies()
    {

    }

    public AbstractSupplies(int[] typeCount)
    {
        for (int i = 0; i < numberOfWoundTypes; i++)
        {
            count[i] = OnlyAllowPositive(typeCount[i], 0);
        }
    }

    public AbstractSupplies(int minorCount, int majorCount, int criticalCount)
    {
        count[(int)WoundType.Minor] = OnlyAllowPositive(minorCount, 0);
        count[(int)WoundType.Major] = OnlyAllowPositive(majorCount, 0);
        count[(int)WoundType.Critical] = OnlyAllowPositive(criticalCount, 0);
    }

    public void EditCount(WoundType type, int change)
    {
        count[(int)type] = OnlyAllowPositive(count[(int)type], change);           
    }
}
