// http://careercup.com/question?id=5733186694807552
//
// Given an array of integers containing equal number of even and odd
// numbers, rearrange the array in such way that the even numbers are 
// at even indexes and odd numbers are at odd indexes.
//

using System;
using System.Linq;

static class Program
{
    static Random random = new Random();

    static int[] Rearrange(this int[] a)
    {
        int evenIndex = 0;
        int oddIndex = 1;
        while (evenIndex < a.Length && oddIndex < a.Length)
        {
            if (a[evenIndex] % 2 == evenIndex % 2) 
            { 
                evenIndex += 2; 
                continue;
            } 

            if (a[oddIndex] % 2 == oddIndex % 2) 
            { 
                oddIndex += 2; 
                continue;
            }

            int c = a[evenIndex];
            a[evenIndex] = a[oddIndex];
            a[oddIndex] = c;
        }

        return a;
    }

    static int[] GenerateArray()
    {
        int halfSize = random.Next(5, 10);
        return Enumerable.
               Range(random.Next(2, 5), halfSize * 2).
               OrderBy(x => random.Next(0, halfSize * 2)).
               ToArray();
    }

    static bool Check(this int[] a)
    {
        return a.
               Select((item, index) => Tuple.Create(item, index)).
               All(x => x.Item1 % 2 == x.Item2 % 2);
    }

    static void Main()
    {
        for (int i = 0; i < 20; i++)
        {
            int[] array = GenerateArray();
            Console.WriteLine("Before: {0} - {1}", 
                              String.Join(", ", array),
                              array.Check());
            Console.WriteLine("After: {0} - {1}", 
                              String.Join(", ", array.Rearrange()),
                              array.Check());
        }
    }
}
