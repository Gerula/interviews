//  http://careercup.com/question?id=5679154655657984

using System;
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

    static String Print(this int[] a)
    {
        return String.Join(", ", a);
    }

    static void Main()
    {
        var a = new [] { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine("{0} - {1}", a.Print(), a.KindaSort().Print());
    }
}
