//  http://www.practice.geeksforgeeks.org/problem-page.php?pid=303
//
//  Given an array of size n and an integer b,
//  traverse the array and if the element in array is b, double b and continue traversal. In the end return value of b.

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int Double(this IEnumerable<int> a, int start)
    {
        return a.Aggregate(start, (acc, x) => x == acc ? acc * 2 : acc);
    }

    static void Main()
    {
        var random = new Random();
        var times = random.Next(10);
        for (var i = 0; i < times; i++)
        {
            var x = Enumerable
                    .Range(1, random.Next(20))
                    .Select(a => random.Next(40))
                    .OrderBy(a => a)
                    .ToArray();
            var start = x[random.Next(x.Length)];
            Console.WriteLine("{0} {1} - {2}", String.Join(", ", x), start, x.Double(start));
        }
    }
}
