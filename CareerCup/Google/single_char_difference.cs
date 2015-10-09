// http://careercup.com/question?id=5760697411567616
//
// Given a string and array of strings, find whether
// the array contains a string with one character difference 
// from the given string.

using System;
using System.Linq;

static class Program 
{
    static String Contains(this String[] a, String s)
    {
        long hash = s.Hash();
        return a.FirstOrDefault(y => Math.Abs(y.Hash() - hash).KindaPowerOfಠ_ಠ(27)); 
    }

    static long Hash(this String s)
    {
        return s.Aggregate(0, (acc, x) => acc * 27 + x);
    }
    
    static bool KindaPowerOfಠ_ಠ(this long x, long a)
    {
        while (x % a == 0) 
        {
            x /= a;
        }

        return x < a;
    }

    static void Main()
    {
        String[] a = new [] {"bana", "apple", "banaba", "bonanza", "banamf"};
        String s = "banana";
        Console.WriteLine(a.Contains(s));
    }
}
