//   We have a list of integers, where:
//
//       The integers are in the range 1..n
//       The list has a length of n+1
//   
//   Find the int that appears at least once

using System;

static class Program
{
    static int Dupe(this int[] a)
    {
        for (var i = 0; i < a.Length; i++)
        {
            while (a[i] != i + 1)
            {
                if (a[a[i] - 1] == a[i])
                {
                    return a[i];
                }

                var c = a[a[i] - 1];
                a[a[i] - 1] = a[i];
                a[i] = c;
            }
        }

        return -1;
    }

    static void Main()
    {
        Console.WriteLine(new [] { 1, 2, 3, 2, 2, 4 }.Dupe());
        Console.WriteLine(new [] { 1, 2, 3, 4, 5, 1 }.Dupe());
    }
}
