// http://www.geeksforgeeks.org/find-the-element-before-which-all-the-elements-are-smaller-than-it-and-after-which-all-are-greater-than-it/
//
// Given an array, find an element before which all elements are smaller than it,
// and after which all are greater than it. Return index of the element if there is such an element,
// otherwise return -1.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int Middle(this int[] a)
    {
        var leftMax = new int[a.Length];
        var rightMin = new int[a.Length];
        leftMax[0] = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], a[i]);
        }

        rightMin[a.Length - 1] = a[a.Length - 1];
        for (int i = a.Length - 2; i >= 0; i--)
        {
            rightMin[i] = Math.Min(rightMin[i + 1], a[i]);
        }

        for (int i = 0; i < a.Length; i++)
        {
            if (leftMax[i] == rightMin[i])
            {
                return a[i];
            }
        }

        return -1;
    }

    static void Main()
    {
        Console.WriteLine(new [] {5, 1, 4, 3, 6, 8, 10, 7, 9}.Middle());
        Console.WriteLine(new [] {5, 1, 4, 4}.Middle());
    }
}
