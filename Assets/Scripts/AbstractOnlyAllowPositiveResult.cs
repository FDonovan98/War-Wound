public class AbstractOnlyAllowPositiveResult
{
    //Will only return a positive or 0 value
    public int OnlyAllowPositive(int value, int change)
    {
        if ((value += change) > 0)
        {
           return value;
        } else
        {
            return 0;
        }
    }
}
