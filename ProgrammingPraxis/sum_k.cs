// http://careercup.com/question?id=5727804001878016
//
// Given a sorted array of positive integers and a positive value
// return all pairs which differ by k.

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<Tuple<int, int>> Pairs(this int[] array, int k)
    {
        for (int low = 0, high = 1; low < high && high < array.Length;)
        {
            int diff = array[high] - array[low];
            if (diff == k) 
            {
                yield return Tuple.Create(array[low], array[high]);
                high++;
            }
            
            if (diff < k)
            {
                high++;
            }
            else
            {
                low++;
            }
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine,
                                      new int[] {1, 2, 3, 5, 6, 8, 9, 11, 12, 13}.
                                      Pairs(3).
                                      Select(x => String.Format("First: {0} Second: {1}", 
                                                                x.Item1,
                                                                x.Item2))));
    }
}
