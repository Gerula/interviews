//  https://leetcode.com/problems/maximum-product-subarray/
//   Find the contiguous subarray within an array (containing at least one number) which has the largest product.
//
//   For example, given the array [2,3,-2,4],
//   the contiguous subarray [2,3] has the largest product = 6.
//
//  https://leetcode.com/submissions/detail/58317732/
//
//  Submission Details
//  183 / 183 test cases passed.
//      Status: Accepted
//      Runtime: 180 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public int MaxProduct(int[] nums) {
        if (!nums.Any())
        {
            return 0;
        }
        
        var maxProduct = nums.First();
        var currentMax = nums.First();
        var currentMin = nums.First();
        foreach (var x in nums.Skip(1))
        {
            var localMax = Math.Max(Math.Max(x, currentMax * x), currentMin * x);
            var localMin = Math.Min(Math.Min(x, currentMax * x), currentMin * x);
            currentMax = localMax;
            currentMin = localMin;
            maxProduct = Math.Max(maxProduct, currentMax);
        }
        
        return maxProduct;
    }
}
