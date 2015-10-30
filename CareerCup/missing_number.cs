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
                ToArray();
    }

    static int Missing(this int[] a)
    {
        return a.
                Select((item, index) => new { item, index } ).
                Aggregate(a.Last(), (acc, x) => {
                    return acc ^ x.item ^ x.index;
                });
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            var input = 30.Generate();
            Console.WriteLine("{0} - {1}",
                              String.Join(", ", input),
                              input.Missing());
        }
    }
}
