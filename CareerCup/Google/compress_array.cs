// http://careercup.com/question?id=5693954190213120
//
// Given an ordered array, find segments
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<int[]> Segment(this int[] array)
    {
        int n = array.Length;
        int start = array[0];
        for (int i = 1; i < n - 1; i++)
        {
            if (array[i] + 1 != array[i + 1])
            {
                yield return 
                        array[i] != start ? 
                            new [] {start, array[i]} :
                            new [] {array[i]};
                start = array[i + 1];
            }
        }

        yield return 
                array.Last() != start ? 
                    new [] {start, array.Last()} :
                    new [] {array.Last()};
    }

    static void Main()
    {
        Random rand = new Random();
        for (int i = 0; i < rand.Next(5, 100); i++)
        {
            int size = rand.Next(10, 40);
            int[] array = new int[size];
            for (int k = 0; k < size; k++)
            {
                int random = rand.Next(1, 5);
                array[k] = (k != 0 ? array[k - 1] + 1 : 0) + random % 2;
            }

            Console.WriteLine(String.Join(", ", array));
            Console.WriteLine(String.Join(
                                            ", ", 
                                            array.Segment().
                                                            Select(x => 
                                                            String.Format(x.Length == 1 ? "{0}" : "[{0}]",
                                                                          String.Join(", ",x)))));
            Console.WriteLine();
        }
    }
}
