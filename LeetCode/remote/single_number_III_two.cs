//  https://leetcode.com/problems/single-number-iii/
//
//   Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice.
//   Find the two elements that appear only once.
//
//   For example:
//
//   Given nums = [1, 2, 1, 3, 2, 5], return [3, 5]. 
//
//   https://leetcode.com/submissions/detail/53328421/
//
//
//   Submission Details
//   30 / 30 test cases passed.
//      Status: Accepted
//      Runtime: 492 ms
//          
//          Submitted: 1 minute ago
//

public class Solution {
    public int[] SingleNumber(int[] nums) {
        var xor = nums.Aggregate(0, (acc, x) => acc ^ x);
        var complement = xor & ~(xor - 1);
        return nums.Aggregate(
            new [] {xor, xor},
            (acc, x) => {
                acc[(x & complement) == 0 ? 0 : 1] ^= x;
                return acc;
            });
    }
}
