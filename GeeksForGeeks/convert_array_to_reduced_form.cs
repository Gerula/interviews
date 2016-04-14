//  http://www.geeksforgeeks.org/convert-array-reduced-form/
//
//  Given an array with n distinct elements, convert the given array to a form where all elements are in range from 0 to n-1.
//  The order of elements is same, i.e., 0 is placed in place of smallest element, 1 is placed for second smallest element, … n-1 is placed for largest element.
//
//  Input:  arr[] = {10, 40, 20}
//  Output: arr[] = {0, 2, 1}
//
//  Input:  arr[] = {5, 10, 40, 30, 20}
//  Output: arr[] = {0, 1, 4, 3, 2}

using System;
using System.Linq;

static class Program
{
    static int[] Sort(this int[] a)
    {
        return Enumerable
               .Range(0, a.Length)
               .OrderBy(x => a[x])
               .ToArray();
    }

    static void Main()
    {
        foreach (var a in new [] { new [] {10, 40, 20},
                                   new [] {5, 10, 40, 30, 20}})
        {
            Console.WriteLine(String.Join(", ", a));
            Console.WriteLine(String.Join(", ", a.Sort()));
            Console.WriteLine();
        }
    }
}

