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
    public static int NumberOfWoundTypes = Enum.GetNames(typeof(WoundType)).Length;

    //Stores how many {Minor, Major, Critical} this item has
    public int[] Count = {0, 0, 0};

    public void SetCount(int[] TypeCount)
    {
        for (int i = 0; i < NumberOfWoundTypes; i++)
        {
            Count[i] = OnlyAllowPositive(TypeCount[i], 0);
        }
    }

    public void SetCount(int MinorCount, int MajorCount, int CriticalCount)
    {
        Count[(int)WoundType.Minor] = OnlyAllowPositive(MinorCount, 0);
        Count[(int)WoundType.Major] = OnlyAllowPositive(MajorCount, 0);
        Count[(int)WoundType.Critical] = OnlyAllowPositive(CriticalCount, 0);
    }

    //Needed so class can be called without passing constructors
    public AbstractSupplies()
    {

    }

    public AbstractSupplies(int[] TypeCount)
    {
        for (int i = 0; i < NumberOfWoundTypes; i++)
        {
            Count[i] = OnlyAllowPositive(TypeCount[i], 0);
        }
    }

    public AbstractSupplies(int MinorCount, int MajorCount, int CriticalCount)
    {
        Count[(int)WoundType.Minor] = OnlyAllowPositive(MinorCount, 0);
        Count[(int)WoundType.Major] = OnlyAllowPositive(MajorCount, 0);
        Count[(int)WoundType.Critical] = OnlyAllowPositive(CriticalCount, 0);
    }

    public void EditCount(WoundType Type, int Change)
    {
        Count[(int)Type] = OnlyAllowPositive(Count[(int)Type], Change);           
    }
}
