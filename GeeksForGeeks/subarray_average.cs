//  http://www.geeksforgeeks.org/find-subarray-least-average/
//
//
//  Find the subarray with least average
//
//  Given an array arr[] of size n and integer k such that k <= n.
//
//  Input:  arr[] = {3, 7, 90, 20, 10, 50, 40}, k = 3
//  Output: Subarray between indexes 3 and 5
//  The subarray {20, 10, 50} has the least average 
//  among all subarrays of size 3.
//
//  Input:  arr[] = {3, 7, 5, 20, -10, 0, 12}, k = 2
//  Output: Subarray between [4, 5] has minimum average
//

using System;
// ONE LINER!!!
using System.Linq;

static class Solution
{
    static float LeastAvg(this int[] a, int k)
    {
        return
        Enumerable
        .Range(0, a.Length - k + 1)
        .Select(x => a.Skip(x).Take(k).Sum() / (float) k)
        .Min();
    }

    static void Main()
    {
        Console.WriteLine(new [] { 3, 7, 90, 20, 10, 50, 40 }.LeastAvg(3));
        Console.WriteLine(new [] { 3, 7, 90, 20, -10, 0, 12 }.LeastAvg(2));
    }
}
