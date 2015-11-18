// Write an efficient function that checks whether any permutation ↴ of an input string is a palindrome ↴ .
//
// Examples:
//
// "civic" should return True
// "ivicc" should return True
// "civil" should return False
// "livci" should return False
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static bool Palindrome(this String s)
    {
        var map = s.Aggregate(
                    new HashSet<char>(),
                    (acc, x) => {
                        if (acc.Contains(x))
                        {
                            acc.Remove(x);
                        }
                        else
                        {
                            acc.Add(x);
                        }

                        return acc;
                    });

        return !map.Any() || map.Count == 1;
    }

    static void Main()
    {
        new [] {
            Tuple.Create("civic", true),
            Tuple.Create("ivicc", true),
            Tuple.Create("civil", false),
            Tuple.Create("livci", false)
        }
        .ToList()
        .ForEach(x => {
                    Console.WriteLine("{0} {1}", x.Item1, x.Item1.Palindrome());
                    if (x.Item1.Palindrome() != x.Item2)
                    {
                        throw new Exception("U suck");
                    }
                });
    }
}
