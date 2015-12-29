//   We have a list of integers, where:
//
//       The integers are in the range 1..n
//       The list has a length of n+1
//   
//   Find the int that appears at least once

using System;
using System.Linq;

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

    static int Dupe2(this int[] a)
    {
        var low = 1;
        var high = a.Length - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;

            var lowFloor = low;
            var lowCeiling = mid;
            var highFloor = mid + 1;
            var highCeiling = high;
            
            var lowElements = a.Where(x => x >= lowFloor && x <= lowCeiling).Count();
            if (lowElements > lowCeiling - lowFloor + 1)
            {
                low = lowFloor;
                high = lowCeiling;
            }
            else
            {
                low = highFloor;
                high = highCeiling;
            }
        }

        return low;
    }

    //       1
    //     1 0
    //     1 1
    //   1 0 0
    //   1 0 1
    //   0 0 1

    static void Main()
    {
        Console.WriteLine(new [] { 1, 2, 3, 2, 2, 4 }.Dupe());
        Console.WriteLine(new [] { 1, 2, 3, 4, 5, 1 }.Dupe());
        Console.WriteLine(new [] { 1, 2, 3, 2, 2, 4 }.Dupe2());
        Console.WriteLine(new [] { 1, 2, 3, 4, 5, 1 }.Dupe2());
    }
}
