public class AbstractOnlyAllowPositiveResult
{
    //Will only return a positive or 0 value
    public int OnlyAllowPositive(int Value, int Change)
    {
        if ((Value += Change) > 0)
        {
           return Value;
        } else
        {
            return 0;
        }
    }
}
