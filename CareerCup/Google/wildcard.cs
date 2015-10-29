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

        var newResult = new List<String>();
        foreach (var localResult in result)
        {
            foreach (var forwardResult in s.Substring(1).Regenerate())
            {
                newResult.Add(localResult + forwardResult);
            }
        }

        return newResult;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, "01?0?".Regenerate()));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, "0?10??".Regenerate()));
    }
}
