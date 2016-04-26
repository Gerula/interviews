//  http://www.geeksforgeeks.org/count-minimum-steps-get-given-desired-array/
//  Consider an array with n elements and value of all the elements is zero. We can perform following operations on the array.
//
//  Incremental operations:Choose 1 element from the array and increment its value by 1.
//  Doubling operation: Double the values of all the elements of array.
//
//  We are given desired array target[] containing n elements. Compute and return the smallest possible number of the operations needed to change the array from all zeros to desired array.

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution
{
    static int Mutations(this int[] a)
    {
        if (a.All(x => x == 0))
        {
            return 0;
        }

        if (a.All(x => x % 2 == 0))
        {
            return 1 + a.Select(x => x / 2).ToArray().Mutations();
        }

        var mutations = 0;
        for (var i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 == 1)
            {
                a[i]--;
                mutations++;
            }
        }

        return mutations + a.Mutations();
    }

    static void Main()
    {
        foreach (var x in new [] {
                    new [] { 2, 3 },
                    new [] { 2, 1 },
                    new [] { 16, 16, 16 }
                })
        {
            Console.WriteLine(
                    "{0} = {1}",
                    String.Join(", ", x),
                    x.Mutations());
        }
    }
}
