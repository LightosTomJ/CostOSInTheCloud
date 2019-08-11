//----------------------------------------------------------------------------------------
//	Copyright © 2007 - 2019 Tangible Software Solutions, Inc.
//	This class can be used by anyone provided that the copyright notice remains intact.
//
//	This class includes methods to convert Java rectangular arrays (jagged arrays
//	with inner arrays of the same length).
//----------------------------------------------------------------------------------------

namespace Desktop.common
{

    internal static class RectangularArrays
    {
        public static System.Nullable<T>[][] RectangularSystemNullableArray<T>(int size1, int size2)
        {
            System.Nullable<T>[][] newArray = new System.Nullable<T>[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new System.Nullable<T>[size2];
            }

            return newArray;
        }

        public static object[][] RectangularObjectArray(int size1, int size2)
        {
            object[][] newArray = new object[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new object[size2];
            }

            return newArray;
        }

        public static Color[][] RectangularColorArray(int size1, int size2)
        {
            Color[][] newArray = new Color[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new Color[size2];
            }

            return newArray;
        }
    }
}