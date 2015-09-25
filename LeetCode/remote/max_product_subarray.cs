// https://leetcode.com/problems/maximum-product-subarray/
//
//  Find the contiguous subarray within an array (containing at least one number) which has the largest product.
//
//  For example, given the array [2,3,-2,4],
//  the contiguous subarray [2,3] has the largest product = 6. 
//
// 
// Submission Details
// 183 / 183 test cases passed.
//  Status: Accepted
//  Runtime: 168 ms
//      
//      Submitted: 0 minutes ago
//
using System;

class Program {
    public static int MaxProduct(int[] nums) {
        int max = int.MinValue;
        int leftProduct = 1;
        int rightProduct = 1;
        for (int i = 0; i < nums.Length; i++) {
            leftProduct *= nums[i];
            rightProduct *= nums[nums.Length - i - 1];
            int maxLocal = leftProduct > rightProduct ? leftProduct : rightProduct;
            max = maxLocal > max ? maxLocal : max;
            if (leftProduct == 0) {
                leftProduct = 1;
            }

            if (rightProduct == 0) {
                rightProduct = 1;
            }
        }

        return max;
    }

    static void Main() {
        int[] array = new []{-1, -1, 2, 3, -2, -3};
        Console.WriteLine(MaxProduct(array));
    }
}
