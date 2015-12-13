//  http://careercup.com/question?id=5113734827606016

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int Hash(this String s)
    {
        return s.Aggregate(0, (acc, x) => acc | (1 << (x - 'a')));
    }

    static int MaxLen(this String[] a)
    {
        return a
               .SelectMany(
                       x => a
                            .Select(
                                y => (x.Hash() & y.Hash()) == 0 ? x.Length * y.Length : 0)).Max();
    }

    static void Main()
    {
        Console.WriteLine(new [] {"abcw", "baz", "foo", "bar", "xtfn", "abcdef"}.MaxLen());
    }
}
