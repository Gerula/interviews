//  https://leetcode.com/problems/single-number-iii/
//
//   Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice.
//   Find the two elements that appear only once.
//
//   For example:
//
//   Given nums = [1, 2, 1, 3, 2, 5], return [3, 5]. 
//
//  Submission Details
//  30 / 30 test cases passed.
//      Status: Accepted
//      Runtime: 496 ms
//          
//          Submitted: 9 hours, 35 minutes ago

public class Solution {
    public int[] SingleNumber(int[] nums) {
        var exclusiveAll = nums.Aggregate(0, (acc, x) => acc ^ x);
        var lastBit = exclusiveAll & - exclusiveAll;
        var first = exclusiveAll;
        var second = exclusiveAll;
        foreach (var x in nums)
        {
            if ((x & lastBit) != 0)
            {
                first ^= x;
            }
            else
            {
                second ^= x;
            }
        }

        return new [] { first, second };
    }
}

//  https://leetcode.com/submissions/detail/58787219/
public class Solution {
    public int[] SingleNumber(int[] nums) {
        var xor = nums.Aggregate((acc, x) => acc ^ x);
        xor &= 1 - xor;
        return nums.Aggregate(
            new int[2],
            (acc, x) => {
                acc[(x & xor) == 0 ? 0 : 1] ^= x;
                return acc;
            }
            );
    }
}
