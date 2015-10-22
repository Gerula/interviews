// You have a sorted array containing the age of every person on earth.
// Find out how many people have a certain age.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static Random rand = new Random();
    static void Times(this int n, Action a)
    {
        while (--n >= 0)
        {
            a();
        }
    }

    static int[] GenerateAges()
    {
        return Enumerable.
                Range(1, 100).
                SelectMany(x => Enumerable.Repeat(x, rand.Next(1, 100))).
                ToArray();
    }

    static Dictionary<int, int> Occurences(this int[] a)
    {
        return a.Aggregate(new Dictionary<int, int>(),
                           (acc, x) => {
                                if (!acc.ContainsKey(x))
                                {
                                    acc[x] = 0;
                                }

                                acc[x]++;
                                return acc;
                           });
    }

    static void Main()
    {
        var input = GenerateAges();
        Console.WriteLine(String.Join(", ", input));
        Console.WriteLine(String.Join(Environment.NewLine, input.Occurences().Select(x => String.Format("{0} - {1}", x.Key, x.Value))));
    }
}
