// http://careercup.com/question?id=6234634354425856
//
// Given n, generate parenthesis
//

using System;
using System.Collections.Generic;

static class Program
{
    static List<String> Gen(this int n, int open = 0, int closed = 0, String partial = "")
    {
        var result = new List<String>();
        if (open == n && closed == n)
        {
            result.Add(partial);
        }

        if (open < n)
        {
            result.AddRange(n.Gen(open + 1, closed, partial + "("));
        }

        if (closed < open)
        {
            result.AddRange(n.Gen(open, closed + 1, partial + ")"));
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, 2.Gen()));
    }
}
