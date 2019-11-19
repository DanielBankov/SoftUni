using System;
using System.Linq;

class RubiksMatrix
{
    static void Main()
    {
        int[] array = new int[6];
        array[0] = 1;
        array[1] = 3;
        array[2] = 5;
        array[3] = 7;
        array[4] = 8;
        array[5] = 5;

        int index1 = Array.IndexOf(array, 2);

        int index2 = Array.IndexOf<int>(array, 3);

        int index3 = Array.LastIndexOf(array, 5);

        Console.WriteLine(index1);
        Console.WriteLine(index2);
        Console.WriteLine(index3);

    }
}
