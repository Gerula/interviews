//  https://leetcode.com/problems/intersection-of-two-arrays/
//  Given two arrays, write a function to compute their intersection. 
//  https://leetcode.com/submissions/detail/61852491/
//
//  Submission Details
//  60 / 60 test cases passed.
//      Status: Accepted
//      Runtime: 532 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        return new HashSet<int>(nums1).Intersect(new HashSet<int>(nums2)).ToArray();
    }
}
