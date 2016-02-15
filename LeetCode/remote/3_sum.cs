//  https://leetcode.com/problems/3sum/
//
//  Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
//
//  Note:
//
//      Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
//      The solution set must not contain duplicate triplets.
//
//      For example, given array S = {-1 0 1 2 -1 -4},
//
//      A solution set is:
//             (-1, 0, 1)
//             (-1, -1, 2)
//  
//  https://leetcode.com/submissions/detail/53475394/
//
//
//  Submission Details
//  311 / 311 test cases passed.
//      Status: Accepted
//      Runtime: 520 ms
//          
//          Submitted: 0 minutes ago
//
//  You are here!
//  Your runtime beats 75.00% of csharp submissions.

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        if (nums.Length < 3)
        {
            return result;
        }
        
        Array.Sort(nums);
        var n = nums.Length;
        for (var low = 0; low < n - 1 && nums[low] <= 0; low++)
        {
            if (low > 0 && nums[low] == nums[low - 1])
            {
                continue;
            }
            
            var mid = low + 1;
            var high = n - 1;
            while (mid < high)
            {
                var sum = nums[low] + nums[mid] + nums[high];
                if (sum == 0)
                {
                    result.Add(new List<int> { nums[low], nums[mid], nums[high] });
                    while (mid < high && nums[mid] == nums[mid + 1])
                    {
                        mid++;
                    }
                    
                    while (mid < high && nums[high] == nums[high - 1])
                    {
                        high--;
                    }
                    
                    mid++;
                    high--;
                }
                else if (sum < 0)
                {
                    mid++;
                }
                else
                {
                    high--;
                }
            }
        }
        
        return result;
    }
}
