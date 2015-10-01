// http://qa.geeksforgeeks.org/3631/arrange-the-elements-into-a-alternating-sequence
//
using System;
using System.Linq;

static class Program
{
    static int[] Sort(this int[] a)
    {
        for (int i = 0; i < a.Length; i += 2) 
        {
            if (i > 0 && a[i] < a[i - 1] || 
                i < a.Length - 1 && a[i] < a[i + 1]) 
            {
                int c = a[i];
                a[i] = a[i + 1];
                a[i + 1] = c;
            }
        }

        return a;
    }

    static void Main()
    {
        Console.WriteLine(
                String.Join(", ",
                    Enumerable.Range(0,20).
                            ToArray().Sort()));
    }
}
