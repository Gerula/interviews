using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int MissingNumber(this String s)
    {
        var setOfNumbers = 
        Enumerable.
        Range(1, s.Length / 2)
        .Select(x =>
                {
                    var numbers = new List<int>();
                    for (int i = 0; i < s.Length; i += x)
                    {
                        String substring = s.Substring(i, Math.Min(x, s.Length - i));
                        if (!String.IsNullOrWhiteSpace(substring))
                        {
                            numbers.Add(int.Parse(substring));
                        }
                    }

                    return numbers;
                });

        var bestMatch = setOfNumbers.
                        OrderBy(x =>
                                    x.Zip(x.Skip(1), (a, b) => b - a).Count(y => y == 1)
                               ).
                        Last();

        return Enumerable.
               Range(
                     bestMatch.First(), 
                     bestMatch.Last() - bestMatch.First()).
               Except(bestMatch).
               First();
    }

    static void Main()
    {
        String s = "596597598600601602";
        Console.WriteLine(s.MissingNumber());
    }
}
