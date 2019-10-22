using UnityEngine;

using System.IO;

public class AbstractReadWoundedData : MonoBehaviour
{
    private AbstractWoundedClass[] wounded;

    //Uses custom function to convert text file to class StringReader containing all of the text and the number of lines in the file. Each line in the file is then used to generate an item in the 'wounded' array.
    public AbstractWoundedClass[] ReadInWounded()
    {
        AbstractGenerateStringReader.GenerateStringReader("WoundedNames", out StringReader woundedNamesReader, out int lineCount);
        
        wounded = new AbstractWoundedClass[lineCount];

        for(int i = 0; i < lineCount; i++)
        {
            wounded[i] = new AbstractWoundedClass(woundedNamesReader.ReadLine());
        }

        ///////////// Debug to print all names read in
        //for (int i = 0; i < wounded.Length; i++)
        //{
        //    Debug.Log(wounded[i].Name);
        //}
        /////////////

        return wounded;

    }

}
