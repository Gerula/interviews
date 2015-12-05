//  https://leetcode.com/problems/median-of-two-sorted-arrays/
//
//  There are two sorted arrays nums1 and nums2 of size m and n respectively.
//  Find the median of the two sorted arrays.
//  The overall run time complexity should be O(log (m+n)).
//

using System;

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var n = nums2.Length;
        var m = nums1.Length;
        if (m > n)
        {
            var c = nums2; nums2 = nums1; nums1 = c;
            var d = m; m = n; n = m;
        }

        var imin = 0;
        var imax = m;
        var half = (m + n + 1) / 2;
        while (imin < imax)
        {
            i = (imin + imax) / 2;
            j = half - 1;

        }
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.FindMedianSortedArrays(new [] { 1, 3, 5, 7 }, new [] { 2, 4, 6, 8, 10 }));
    }
}
