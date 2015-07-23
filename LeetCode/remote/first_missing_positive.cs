// https://leetcode.com/submissions/detail/33873237/

public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int i = 0;
        while (i < nums.Length) {
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1]) {
                int aux = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = aux;
            }
            
            i++;
        }
        
        for (i = 0; i < nums.Length; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }
        
        return nums.Length + 1;
    }
}

