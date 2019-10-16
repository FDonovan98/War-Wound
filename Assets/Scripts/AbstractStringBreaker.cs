using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractStringBreaker
{
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