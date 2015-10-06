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
        array = array.OrderBy(x => x).ToArray();
        int min = 0;
        int max = array.Length - 1;
        int sum = array[min] + array[max];
        Console.WriteLine(array[max]);
        if (sum >= 0)
        {
            return Tuple.Create(array[min], array[max]);
        }
        
        while (sum < 0 && min < array.Length)
        {
            min++;
            sum = array[min] + array[max];
        }

        return Tuple.Create(array[min - 1], array[max]);
    }

    static void Main()
    {
        Console.WriteLine(new int[] { 45, -29, -96, -7, -17, 72, -60 }.TwoSumClosest());
    }
}
