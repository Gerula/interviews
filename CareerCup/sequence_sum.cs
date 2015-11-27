// http://careercup.com/question?id=6305076727513088
//
// Given an array and a value x, return if there is a consecutive sequence
// of numbers from a which sum up to exactly x.
//

using System;

static class Program
{
    static bool Sum(this int[] a, int target)
    {
        var low = 0;
        var high = 0;
        var sum = a[0];
        while (low < a.Length && high < a.Length)
        {
            if (sum == target)
            {
                return true;
            }

            if (sum < target)
            {
                high++;
                sum += a[high];        
            }

            if (sum > target)
            {
                sum -= a[low];
                low++;
            }
        }

        return false;
    }

    static void Main()
    {
        Console.WriteLine(new []{23, 5, 4, 7, 2, 11}.Sum(20));
        Console.WriteLine(new []{1, 3, 5, 23, 2, 8}.Sum(8));
        Console.WriteLine(new []{1, 3, 5, 23, 2, 8}.Sum(7));
    }
}
