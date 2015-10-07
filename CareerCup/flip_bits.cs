// http://careercup.com/question?id=6262507668766720
//
// You are given a binary array and you can perform at most one
// operation on the array, choose any two integers L and R and flip
// al the elements between and including the L and R bits.
//
// What is the maximum number of 1 bits which you can obtain in the final
// bit array?

using System;
using System.Linq;

static class Program
{
    static Tuple<int, int, int> MaxFlip(this int[] a)
    {
        int left = 0;
        int maxLeft = 0;
        int maxRight = 0;
        int sum = 0;
        int maxSum = 0;
        
        for (int i = 0; i < a.Length; i++)
        {
            sum += a[i] == 1 ? -1: 1;
            if (sum > maxSum)
            {
                maxLeft = left;
                maxRight = i;
                maxSum = sum;
            }

            if (sum <= 0)
            {
                left = i + 1;
                sum = 0;
            }
        }

        for (int i = maxLeft; i <= maxRight; i++) 
        {
            a[i] = 1 - a[i];
        }

        return Tuple.Create(maxLeft, maxRight, a.Sum());
    }

    static void Main()
    {
        if (!new int[] {1, 0, 0, 1, 0, 0, 1, 0}.MaxFlip().Equals(Tuple.Create(1, 5, 6)))
        {
            throw new Exception("U r dumb!");
        }

        Console.WriteLine("U r probably not dumb");
    }
}
