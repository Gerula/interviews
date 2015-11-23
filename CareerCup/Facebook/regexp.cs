// http://careercup.com/question?id=6631993756352512
//
// Given a regular expression with characters a-z, * and .
// find if it matches a given string.
//

using System;
using System.Collections.Generic;

static class Program
{
    static bool Match(this String regex, String other)
    {
        return true;
    }

    static void Main()
    {
        foreach (var input in new[] {
                    Tuple.Create("a*", "", true),
                    Tuple.Create(".", "", false),
                    Tuple.Create("ab*", "a", true),
                    Tuple.Create("a.", "ab", true),
                    Tuple.Create("a", "a", true),
                    Tuple.Create("a*bc", "aaaaaaaabc", true)
                })
        {
            var result = input.Item1.Match(input.Item2);
            Console.WriteLine("{0} - {1}", input, result);
            if (input.Item3 != result)
            {
                throw new Exception("You suck");
            }
        }
    }
}
