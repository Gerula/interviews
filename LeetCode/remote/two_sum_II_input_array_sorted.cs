//  https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
//  https://leetcode.com/submissions/detail/84032365/
//
//  Submission Details
//  15 / 15 test cases passed.
//      Status: Accepted
//      Runtime: 442 ms
//          Submitted: 0 minutes ago
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var low = 0;
        var high = numbers.Length - 1;
        while (low < high) {
            var sum = numbers[low] + numbers[high];
            if (sum == target) {
                return new [] { low + 1, high + 1};
            }

            if (sum < target) {
                low++;
            } else {
                high--;
            }
        }

        return new int[2];
    }
}
