// http://careercup.com/question?id=5676298150084608
//
// Given an array of ranges, return an optimized array
// by deleting subarrays
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static bool Include(this Tuple<int, int> first, Tuple<int, int> second)
    {
        return first.Item1 <= second.Item1 &&
               first.Item2 >= second.Item2;
    }

    static Tuple<int,int>[] Optimize(this Tuple<int, int>[] a)
    {
        a = a.OrderBy(x => x.Item1).ToArray();
        int count = 1;
        for (int i = 2; i < a.Length; i++)
        {
            if (a[count - 1].Include(a[i])) 
            {
                continue;
            }

            if (a[i].Include(a[count - 1]))
            {
                a[count - 1] = a[i];
                continue;
            }

            a[count] = a[i];
            count++;
        }

        return a.Take(count).ToArray();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ",
                new [] {
                    Tuple.Create(2, 6),
                    Tuple.Create(3, 5),
                    Tuple.Create(7, 21),
                    Tuple.Create(20, 21),
                    Tuple.Create(1, 30)
                }.
                Optimize().
                Select(x => String.Format("[{0}, {1}]", x.Item1, x.Item2))));
    }
}

