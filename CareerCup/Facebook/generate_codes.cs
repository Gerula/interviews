// http://careercup.com/question?id=19300678
//
// For a = 1, b = 2, c = 3, ... , z = 26, given a string
// find all possible codes that the string can generate.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static String ToLetter(this int n)
    {
        return ((char)('a' + n - 1)).ToString();
    }

    static List<String> Decode(this String s)
    {
        if (String.IsNullOrEmpty(s))
        {
            return new List<String>();
        }

        var result = new List<String>();
        if (int.Parse(s) < 27)
        {
            result.Add(int.Parse(s).ToLetter());
        }

        return Enumerable
               .Range(1, s.Length - 1)
               .Select(x => int.Parse(s.Substring(0, x)))
               .Where(y => y < 27)
               .SelectMany(z => s.Substring(z.ToString().Length).Decode(),
                          (a, b) => a.ToLetter() + b)
               .Concat(result)
               .ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, "1123".Decode()));
    }
}
