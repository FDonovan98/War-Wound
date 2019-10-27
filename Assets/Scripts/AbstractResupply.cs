public class AbstractResupply : AbstractSupplies
{
    //Increases the count of one AbstractSupplies variable by the count of another. Used when doing a resupply
    public static AbstractSupplies DoResupply(AbstractSupplies AvailableSupplies, AbstractSupplies Resupply)
    {
        for(int i = 0; i < NumberOfWoundTypes; i++)
        {
            AvailableSupplies.EditCount((WoundType)i, Resupply.Count[i]);
        }
        return AvailableSupplies;
    }
}