//  http://careercup.com/question?id=5679154655657984

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int[] KindaSort(this int[] a)
    {
        var sorted = a.OrderBy(x => x).Reverse();
        return sorted
               .Take(sorted.Count() / 2)
               .Zip(sorted.Skip(sorted.Count() / 2).Take(sorted.Count() - sorted.Count() / 2).Reverse(),
                    (x, y) => new [] {x, y})
               .SelectMany(x => x)
               .ToArray();

    }

    static List<int> KSort(this List<int> a)
    {
        if (!a.Any())
        {
            return a;
        }

        var result = new List<int>();
        result.Add(a.Max());
        a.Remove(a.Max());
        if (a.Any())
        {
            result.Add(a.Min());
            a.Remove(a.Min());
            var next = a.KSort();
            result.AddRange(next);
        }

        return result;
    }

    static String Print(this IEnumerable<int> a)
    {
        return String.Join(", ", a);
    }

    static void Main()
    {
        var a = new [] { 1, 2, 3, 4, 5, 6, 7 };
        var b = a.ToList();
        Console.WriteLine("{0} - {1}", a.Print(), a.KindaSort().Print());
        Console.WriteLine("{0} - {1}", b.Print(), b.KSort().Print());
    }
}
