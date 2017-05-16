//  http://www.geeksforgeeks.org/find-minimum-number-of-merge-operations-to-make-an-array-palindrome/
//  Given an array arr[] of size n. We need to make the given array a ‘Palindrome’.
//  Only allowed operation on array is merge. Merging two adjacent elements means replacing them with their sum.
//  The task is to find minimum number of merge operations required to make given array a ‘Palindrome’.
//
//  To make an array a palindromic we can simply apply merging operations n-1 times where n is the size of array.
//  In that case, size of array will be reduced to 1. But in this problem we are asked to do it in minimum number of operations.

using System;

static class Solution
{
    static int Palind(this int[] a)
    {
        var min = 0;
        for (int i = 0, j = a.Length - 1; i < j;)
        {
            if (a[i] == a[j])
            {
                i++; j--; continue;
            }

            if (a[i] < a[j])
            {
                i++;
                a[i] += a[i - 1];
                min++;
            }
            else
            {
                j--;
                a[j] += a[j + 1];
                min++;
            }
        }

        return min;
    }

    static void Main()
    {
        Console.WriteLine(new [] {1, 4, 5, 1}.Palind());
        Console.WriteLine(new [] {11, 14, 15, 99}.Palind());
    }
}
