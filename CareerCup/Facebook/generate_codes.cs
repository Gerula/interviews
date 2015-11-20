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
    static List<String> Decode(this String s)
    {
        if (String.IsNullOrEmpty(s))
        {
            return new List<String>();
        }

        var result = new List<String>();
        for (var i = 1; i <= s.Length; i++)
        {
            var num = int.Parse(s.Substring(0, i));
            if (num < 27)
            {
                var current = ((char)('a' + num - 1)).ToString(); 
                if (i == s.Length)
                {
                    result.Add(current);
                }
                else
                {
                    foreach (var next in s.Substring(i).Decode())
                    {
                        result.Add(current + next);
                    }
                }
            }
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, "1123".Decode()));
    }
}
