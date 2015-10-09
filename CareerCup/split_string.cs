// http://careercup.com/question?id=5702976138117120
// Split string per pattern
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<String> Split(this String s, IEnumerable<int> pattern)
    {
        int prev = 0;
        foreach (int index in pattern) 
        {
            yield return s.Substring(prev, index - prev + 1);
            prev = index + 1;
        }

        yield return s.Substring(prev, s.Length - prev);
    }

    static void Main()
    {
        String s = "Programmingproblemforidiots";
        Console.WriteLine(String.Join(", ", s.Split(new List<int> {10, 17, 20})));
    }
}
