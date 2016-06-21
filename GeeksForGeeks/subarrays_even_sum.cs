//  http://www.geeksforgeeks.org/find-number-subarrays-even-sum/
//  Given an array, find the number of subarrays whose sum is even.
//
//  Example :
//
//  Input : arr[] = {1, 2, 2, 3, 4, 1} 
//  Output : 9
//
//  There are possible subarrays with even
//  sum. The subarrays are 
//  1) {1, 2, 2, 3}  Sum = 8
//  2) {1, 2, 2, 3, 4}  Sum = 12
//  3) {2}  Sum = 2 (At index 1)
//  4) {2, 2}  Sum = 4
//  5) {2, 2, 3, 4, 1}  Sum = 12
//  6) {2}  Sum = 2 (At index 2)
//  7) {2, 3, 4, 1} Sum = 10
//  8) {3, 4, 1}  Sum = 8
//  9) {4}  Sum = 4 

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution
{
    static int EvenSumsNinja(this int[] a)
    {
        return Enumerable
               .Range(0, a.Length - 1)
               .Select(x => Enumerable
                            .Range(1, a.Length - x)
                            .Select(y => a.Skip(x).Take(y).Sum()))
               .SelectMany(x => x)
               .Count(x => x % 2 == 0);
    }

    static void Main()
    {
        Console.WriteLine(new int[] { 1, 2, 2, 3, 4, 1 }.EvenSumsNinja());
    }
}

