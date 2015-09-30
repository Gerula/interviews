// https://leetcode.com/problems/find-the-duplicate-number/
//
//  Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.
//
//  Note:
//
//      You must not modify the array (assume the array is read only). <--- THIS right here is the fucky part. Because usually with this problem you set the element to it's index
//      You must use only constant, O(1) extra space.
//      Your runtime complexity should be less than O(n2).
//      There is only one duplicate number in the array, but it could be repeated more than once.
// 
// Submission Details
// 53 / 53 test cases passed.
//  Status: Accepted
//  Runtime: 176 ms
//      
//      Submitted: 0 minutes ago
//

using System;

class Program {
    public int FindDuplicate(int[] nums) {
        int slow = nums.Length;
        int fast = nums.Length;

        do
        {
            slow = nums[slow - 1];
            fast = nums[nums[fast - 1] - 1];
        } while (slow != fast);

        slow = nums.Length;
        while (slow != fast)
        {
            slow = nums[slow - 1];
            fast = nums[fast - 1];
        }

        return slow;
    }

    static void Main()
    {
        int[] a = new [] { 1, 7, 2, 6, 1, 5, 4, 3 };
        Console.WriteLine(new Program().FindDuplicate(a));
        a = new [] { 2, 1, 1 };
        Console.WriteLine(new Program().FindDuplicate(a));
    }
}
