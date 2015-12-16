//  https://leetcode.com/submissions/detail/48213000/
//
//  Directly in the browser
//
//
//  Merge Sorted Array
//  Submission Details
//  59 / 59 test cases passed.
//      Status: Accepted
//      Runtime: 472 ms
//          
//          Submitted: 0 minutes ago
//
//  You are here!
//  Your runtime beats 85.71% of csharp submissions

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var first = m - 1;
        var second = n - 1;
        for (var i = m + n - 1; i >= 0; i--)
        {
            if (first < 0 || second >= 0 && nums1[first] < nums2[second])
            {
                nums1[i] = nums2[second--];
            }
            else
            {
                nums1[i] = nums1[first--];    
            }
        }
    }
}
