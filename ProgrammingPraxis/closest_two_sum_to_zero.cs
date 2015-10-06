// http://programmingpraxis.com/2015/06/23/closest-two-sum-to-zero/
//
// Given a random array of integers, both positive and negative,
// find the pair with sum closest to zero. For instance,
// in the array [45, -29, -96, -7, -17, 72, -60], the two integers with sum closest to zero are -60 and 72.
//

using System;
using System.Linq;

static class Program
{
    static Tuple<int, int> TwoSumClosest(this int[] array)
    {
        array = array.OrderBy(a => a).ToArray();
        int left = 0;
        int right = array.Length - 1;
        int minSum = int.MaxValue;
        int leftMax = 0;
        int rightMax = array.Length - 1;

        while (left < right)
        {
            int localSum = array[left] + array[right];
            if (Math.Abs(localSum) < Math.Abs(minSum))
            {
                minSum = localSum;
                leftMax = left;
                rightMax = right;
            }

            if (localSum > 0)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return Tuple.Create(array[leftMax], array[rightMax]);
    }

    static void Main()
    {
        Console.WriteLine(new int[] { 45, -29, -96, -7, -17, 72, -60 }.TwoSumClosest());
    }
}
