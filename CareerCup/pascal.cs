// Print row n of Pascal's triangle.
// Do it like a ninja superstar rock legend code samurai
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static String Pascal(this int n)
    {
        return String.Join(
                ", ",
                Enumerable.
                Range(1, n).
                Aggregate(
                    new List<int> { 1 },
                    (acc, x) =>
                    {
                        var result = new List<int> { 1 };
                        result.AddRange(acc.
                                          Zip(acc.Skip(1), (a, b) => new { a, b }).
                                          Select(y => y.a + y.b));
                        result.Add(1);
                        return result;
                    }));
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                    Environment.NewLine,
                    Enumerable.
                    Range(1, 10).
                    Select(x => x.Pascal())));
    }
}
