// http://careercup.com/question?id=5702373701844992
//
// Sociopathic Dutch National Flag Problem.
// It's like the regular problem but with more asshole (you're not allowed to get the array length)
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Problem
{
    static Random rand = new Random();

    static int[] Generate()
    {
        return Enumerable.
                Range(1, rand.Next(10, 30)).
                Select(x => rand.Next(1, 100) % 3).
                ToArray();
    }

    static String Str(this int[] a)
    {
        return String.Join(String.Empty, a);
    }

    static int[] FlagSort(this int[] a)
    {
        int zero = 0;
        int one = 0;
        int two = a.Length;
        while (one < two)
        {
            switch (a[one])
            {
                case 0: Swap(ref a[zero++], ref a[one++]); break;
                case 1: one++; break;
                case 2: Swap(ref a[one], ref a[--two]); break;
            }
        }

        return a;
    }

    static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            var a = Generate();
            Console.WriteLine(
                    "{0}{1}{2}{1}",
                    a.Str(),
                    Environment.NewLine,
                    a.FlagSort().Str());
        }
    }
}
