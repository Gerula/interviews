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
        int diff = int.MaxValue;
        int first = 0;
        int second = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int localDiff = Math.Abs(array[i] + array[j]);
                if (localDiff < diff)
                {
                    diff = localDiff;
                    first = i;
                    second = j;
                }
            }
        }

        return Tuple.Create(array[first], array[second]);
    }

    static void Main()
    {
        Console.WriteLine(new int[] { 45, -29, -96, -7, -17, 72, -60 }.TwoSumClosest());
    }
}
