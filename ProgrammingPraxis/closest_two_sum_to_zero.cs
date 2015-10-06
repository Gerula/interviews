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
        var sorted = array.
                        Select((item, index) => 
                        Tuple.Create(item, index)).
                        OrderBy(x => Math.Abs(x.Item1)).
                        ToArray().
                        Reverse();

        var sortedPairs = sorted.Zip(sorted.Skip(1), (first, second) => Tuple.Create(first, second));
        var minSumPair = sortedPairs.FirstOrDefault(x => array[x.Item1.Item2] * array[x.Item2.Item2] < 0);
        if (minSumPair == null)
        {
            return Tuple.Create(array[sortedPairs.First().Item1.Item2],
                                array[sortedPairs.First().Item2.Item2]);
        }

        return Tuple.Create(array[minSumPair.Item1.Item2],
                            array[minSumPair.Item2.Item2]);
    }

    static void Main()
    {
        Console.WriteLine(new int[] { 45, -29, -96, -7, -17, 72, -60 }.TwoSumClosest());
    }
}
