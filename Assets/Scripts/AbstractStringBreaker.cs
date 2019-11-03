public class AbstractStringBreaker
{
    //Reads in a string and breaks it into an array of seperate strings
    public static string[] StringBreak(string stringToBreak, char seperator = ',')
    {
        if(stringToBreak != null)
        {
            string[] elements = stringToBreak.Split(seperator);
            return elements;
        } else
        {
            return null;
        }
    }
}