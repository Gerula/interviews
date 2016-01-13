//  https://leetcode.com/problems/permutation-sequence/
//
//  The set [1,2,3,…,n] contains a total of n! unique permutations.
//
//  By listing and labeling all of the permutations in order,
//  We get the following sequence (ie, for n = 3):
//
//      "123"
//      "132"
//      "213"
//      "231"
//      "312"
//      "321"
//
//  Given n and k, return the kth permutation sequence.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    //  
    //  Submission Details
    //  200 / 200 test cases passed.
    //      Status: Accepted
    //      Runtime: 56 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/50522571/
    public string GetPermutation(int n, int k) {
        var factorials = new int[n + 1];
        factorials[0] = 1;
        for (var i = 1; i <= n; i++)
        {
            factorials[i] = i * factorials[i - 1];
        }

        var nums = Enumerable.Range(0, n + 1).Skip(1).ToList();
        
        k--;

        var result = new StringBuilder();
        for (var i = 1; i <= n; i++)
        {
            var idx = k / factorials[n - i];
            result.Append(nums[idx].ToString());
            nums.RemoveAt(idx);
            k -= idx * factorials[n - i];
        }

        return result.ToString();
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.GetPermutation(3, 4));
        Console.WriteLine(s.GetPermutation(1, 1));
    }
}
