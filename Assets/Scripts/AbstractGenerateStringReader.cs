using UnityEngine;
using System.IO;

public class AbstractGenerateStringReader
{
    //Reads in a text file, converts it to class TextAsset and then converts this text asset to class StringReader
    public static void GenerateStringReader(string filename, out StringReader reader, out int lineCount)
    {
        TextAsset FilenameAsset = Resources.Load<TextAsset>("Text Files/" + filename);
        Debug.Assert(FilenameAsset != null, filename + ".txt could not be loaded");

        reader = new StringReader(FilenameAsset.text);

        lineCount = 0;
        while (reader.ReadLine() != null)
        {
            lineCount++;
        }

        reader = new StringReader(FilenameAsset.text);
    }
}
