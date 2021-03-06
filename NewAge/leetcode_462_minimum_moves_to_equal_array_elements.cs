//  https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
//  https://leetcode.com/submissions/detail/87493779/
public class Solution {
    public int MinMoves2(int[] nums) {
        var high = nums.Length - 1;
        var low = 0;
        Array.Sort(nums);
        var result = 0;
        while (low < high) {
            result += nums[high--] - nums[low++];
        }

        return result;
    }

    public int MinMoves2(int[] nums) {
        Array.Sort(nums);
        return nums
               .Take(nums.Length / 2)
               .Zip(
                   nums.Skip(nums.Length / 2).Reverse(),
                   (x, y) => y - x)
               .Sum();
    }
}
