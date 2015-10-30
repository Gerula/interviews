// http://careercup.com/question?id=5096151013392384
//
// Given an array and a number N, meaning that the array
// contains all numbers from 0 to N with one missing.
//
// Find the missing number.
//

using System;
using System.Linq;

static class Program
{
    static Random random = new Random();

    static int[] Generate(this int n)
    {
        var missing = random.Next(1, n);
        return Enumerable.
                Range(0, missing).
                Concat(Enumerable.
                        Range(missing + 1, n - missing)).
                OrderBy(x => random.Next()).
                ToArray();
    }

    // Fascinating!
    //
    //      0 1 2 3 4 5
    //      2 1 4 6 5 0
    //
    //      6 ^ 0 ^ 2 ^ 1 ^ 1 ^ 2 ^ 4 ^ 3 ^ 6 ^ 4 ^ 5 ^ 5 ^ 0
    //      6 ^ 2 ^ 1 ^ 1 ^ 2 ^ 4 ^ 3 ^ 6 ^ 4 ^ 5 ^ 5
    //      6 ^ 2 ^ 1 ^ 1 ^ 2 ^ 4 ^ 3 ^ 6 ^ 4
    //      2 ^ 1 ^ 1 ^ 2 ^ 4 ^ 3 ^ 4
    //      2 ^ 1 ^ 1 ^ 2 ^ 3
    //      1 ^ 1 ^ 3
    //      3 - Genius
    //
    static int Missing(this int[] a)
    {
        return a.
                Select((item, index) => new { item, index } ).
                Aggregate(a.Max(), (acc, x) => {
                    return acc ^ x.item ^ x.index;
                });
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            var input = 30.Generate();
            Console.WriteLine("{0} - {1} - {2}",
                              String.Join(", ", input),
                              input.Missing(),
                              input.Contains(input.Missing()) ? "Still there" : "Not there");
        }
    }
}
