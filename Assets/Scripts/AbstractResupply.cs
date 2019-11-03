public class AbstractResupply : AbstractSupplies
{
    //Increases the count of one AbstractSupplies variable by the count of another. Used when doing a resupply
    public static AbstractSupplies DoResupply(AbstractSupplies availableSupplies, AbstractSupplies resupply)
    {
        for(int i = 0; i < numberOfWoundTypes; i++)
        {
            availableSupplies.EditCount((WoundType)i, resupply.count[i]);
        }
        return availableSupplies;
    }
}