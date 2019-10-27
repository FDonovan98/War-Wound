public class AbstractStringBreaker
{
    //Reads in a string and breaks it into an array of seperate strings
    public static string[] StringBreak(string StringToBreak, char Seperator = ',')
    {
        if(StringToBreak != null)
        {
            string[] Elements = StringToBreak.Split(Seperator);
            return Elements;
        } else
        {
            return null;
        }
    }
}