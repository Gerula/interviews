// http://careercup.com/question?id=6234634354425856
//
// Given n, generate parenthesis
//

using System;
using System.Collections.Generic;

static class Program
{
    static List<String> Gen(this int n)
    {
        var result = new List<String>();
        n.GenRec(0, 0, result, String.Empty);
        return result;
    }

    static void GenRec(this int n, int open, int closed, List<String> result, String partial)
    {
        if (open == n && closed == n)
        {
            result.Add(partial);
            return;
        }

        if (open < n)
        {
            n.GenRec(open + 1, closed, result, partial + "(");
        }

        if (closed < open)
        {
            n.GenRec(open, closed + 1, result, partial + ")");
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, 2.Gen()));
    }
}
