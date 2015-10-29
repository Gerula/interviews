//  http://careercup.com/question?id=5759440689037312
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static List<String> Regenerate(this String s)
    {
        var result = new List<String>();

        if (s.First() == '?')
        {
            result.Add("0");
            result.Add("1");
        }
        else
        {
            result.Add(s.First().ToString());
        }

        if (s.Length == 1)
        {
            return result;
        }

        return result.
                SelectMany(x => s.Substring(1).
                                  Regenerate().
                                  Select(y => String.Format(
                                                        "{0}{1}",
                                                        x,
                                                        y))).
                ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, "01?0?".Regenerate()));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, "0?10??".Regenerate()));
    }
}
