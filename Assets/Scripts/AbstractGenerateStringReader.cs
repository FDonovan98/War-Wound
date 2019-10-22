using UnityEngine;
using System.IO;

public class AbstractGenerateStringReader
{
    //Reads in a text file, converts it to class TextAsset and then converts this text asset to class StringReader
    public static void GenerateStringReader(string Filename, out StringReader Reader, out int LineCount)
    {
        TextAsset FilenameAsset = Resources.Load<TextAsset>("Text Files/" + Filename);
        Debug.Assert(FilenameAsset != null, Filename + ".txt could not be loaded");

        Reader = new StringReader(FilenameAsset.text);

        LineCount = 0;
        while (Reader.ReadLine() != null)
        {
            LineCount++;
        }

        Reader = new StringReader(FilenameAsset.text);
    }
}
