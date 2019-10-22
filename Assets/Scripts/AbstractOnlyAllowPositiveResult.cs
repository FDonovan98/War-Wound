public class AbstractOnlyAllowPositiveResult
{
    //Will only return a positive or 0 value
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
