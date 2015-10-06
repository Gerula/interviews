// http://programmingpraxis.com/2015/03/27/string-re-ordering/
//
// You are given a string O that specifies the desired ordering of letters in a target string T.
// For example, given string O = “eloh” the target string T = “hello” would be re-ordered “elloh”
// and the target string T = “help” would be re-ordered “pelh” (letters not in the order string
// are moved to the beginning of the output in some unspecified order).

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static String Sort(this String s, String order)
    {
        var ordering = Enumerable.Range('a', 27).Aggregate(new Dictionary<char, int>(), (a, b) =>
                         {
                            int idx = order.IndexOf((char) b);
                            a[(char) b] = idx >= 0 ? idx + 1 : 0;
                            return a;
                         });

        return new String(s.OrderBy(x => ordering[x]).ToArray());
    }

    static void Main()
    {
        String[] s = new String[] { "hello", "help" };
        Console.WriteLine(String.Join(", ", s.Select(x => String.Format("{0} - {1}", x, x.Sort("eloh")))));
    }
}
