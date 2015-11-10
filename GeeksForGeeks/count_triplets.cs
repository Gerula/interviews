// http://www.geeksforgeeks.org/count-triplets-with-sum-smaller-that-a-given-value/
//
// Given an array of distinct integers and a sum value.
// Find count of triplets with sum smaller than given sum value.
// Expected Time Complexity is O(n2).
//

using System;

static class Program 
{
    static int Smaller(this int[] a, int threshold)
    {
        Array.Sort(a);
        if (a.Length <= 3)
        {
            return ((a.Length > 0 ? a[0] : 0) +
                    (a.Length > 1 ? a[1] : 0) +
                    (a.Length > 2 ? a[2] : 0) < threshold) ? 1 : 0;
        }

        var result = 0;
        for (int i = 0; i < a.Length - 2; i++)
        {
            int low = i + 1;
            int high = a.Length - 1;
            while (low < high)
            {
                if (a[i] + a[low] + a[high] < threshold)
                {
                    result += high - low;
                    for (var k = low; k < high; k++)
                    {
                        Console.WriteLine("{0} {1} {2}", a[i], a[k], a[high]);
                    }

                    low++;
                }
                else
                {
                    high--;
                }
            }
        }

        Console.WriteLine();
        return result;
    }

    static void Main()
    {
        Console.WriteLine(new [] {-2, 0, 1, 3}.Smaller(2));
        Console.WriteLine(new [] {5, 1, 3, 4, 7}.Smaller(12));
    }
}
