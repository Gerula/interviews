//  http://www.careercup.com/question?id=5705610449387520
//
//  Find the length of a maximum palindrome subset in an array.
//  For example: in 1, 2, 4, 1 the maximum palindrome subset is 1, 2, 1 and the answer is 3

using System;
using System.Linq;

static class Program
{
    static int MaxPalindrome(this int[] a)
    {
        if (a.Count() == 1 || a.Count() == 0)
        {
            return a.Count();
        }

        if (a.First() == a.Last())
        {
            return 2 + a
                       .Skip(1)
                       .Take(a.Count() - 2)
                       .ToArray()
                       .MaxPalindrome();
        }

        return Math.Max(a
                        .Skip(1)
                        .ToArray()
                        .MaxPalindrome(),
                        a
                        .Take(a.Count() - 1)
                        .ToArray()
                        .MaxPalindrome());
    }

    static void Main()
    {
        Console.WriteLine(new [] { 1, 2, 4, 1 }.MaxPalindrome());
    }
}
