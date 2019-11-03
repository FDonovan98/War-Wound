using System;

public class AbstractRemoveItemFromArray
{
    //Removes an item from a class array. A different method is used if the item to be removed is the last in the class array otherwise it would throw an error
    public static object[] RemoveItem(object[] targetArray, int elementPosition)
    {
        if (elementPosition != targetArray.Length - 1)
        {
            for (int j = 0; j < targetArray.Length - 1; j++)
            {
                targetArray[elementPosition] = targetArray[elementPosition + 1];
            }
        } else
        {
            Array.Resize(ref targetArray, targetArray.Length - 1);
        }

        return targetArray;
    }

    //Same as the above function, however works with an int array. 
    public static int[] RemoveItem(int[] targetArray, int elementPosition)
    {
        if (elementPosition != targetArray.Length - 1)
        {
            for (int j = 0; j < targetArray.Length - 1; j++)
            {
                targetArray[elementPosition] = targetArray[elementPosition + 1];
            }
        } else
        {
            Array.Resize(ref targetArray, targetArray.Length - 1);
        }

        return targetArray;
    }
}
