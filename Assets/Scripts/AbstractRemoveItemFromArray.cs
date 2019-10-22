using System;

public class AbstractRemoveItemFromArray
{
    //Removes an item from a class array. A different method is used if the item to be removed is the last in the class array otherwise it would throw an error
    public static object[] RemoveItem(object[] TargetArray, int ElementPosition)
    {
        if (ElementPosition != TargetArray.Length - 1)
        {
            for (int j = 0; j < TargetArray.Length - 1; j++)
            {
                TargetArray[ElementPosition] = TargetArray[ElementPosition + 1];
            }
        } else
        {
            Array.Resize(ref TargetArray, TargetArray.Length - 1);
        }

        return TargetArray;
    }

    //Same as the above function, however works with an int array. 
    public static int[] RemoveItem(int[] TargetArray, int ElementPosition)
    {
        if (ElementPosition != TargetArray.Length - 1)
        {
            for (int j = 0; j < TargetArray.Length - 1; j++)
            {
                TargetArray[ElementPosition] = TargetArray[ElementPosition + 1];
            }
        } else
        {
            Array.Resize(ref TargetArray, TargetArray.Length - 1);
        }

        return TargetArray;
    }
}
