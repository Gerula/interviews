//  https://leetcode.com/problems/sort-colors/
//
//   Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent,
//   with the colors in the order red, white and blue.
//
//   Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively. 

using System;
using System.Linq;

public class Solution {
    //  https://leetcode.com/submissions/detail/48073928/
    //
    //
    //  Submission Details
    //  86 / 86 test cases passed.
    //      Status: Accepted
    //      Runtime: 540 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public static void SortColors(int[] nums) {
        var low = 0;
        var intermediate = 0;
        var high = nums.Length;
        while (intermediate < high)
        {
            switch (nums[intermediate])
            {
                case 0: 
                    Swap(ref nums[intermediate], ref nums[low]);
                    low++;
                    intermediate++;
                    break;
                case 1:
                    intermediate++;
                    break;
                case 2:
                    high--;
                    Swap(ref nums[intermediate], ref nums[high]);
                    break;
            }
        }
    }

    public static void Swap(ref int a, ref int b)
    {
        var c = a;
        a = b;
        b = c;
    }

    //  https://leetcode.com/submissions/detail/60401124/
    //  
    //  Submission Details
    //  86 / 86 test cases passed.
    //      Status: Accepted
    //      Runtime: 488 ms
    //          
    //          Submitted: 1 minute ago
    public void SortColors(int[] nums) {
        var red = 0;
        var undecided = 0;
        var blue = nums.Length;
        while (undecided < blue)
        {
            switch (nums[undecided])
            {
                case 2: Swap(ref nums[--blue], ref nums[undecided]);
                        break;
                case 1: undecided++;
                        break;
                case 0: Swap(ref nums[red++], ref nums[undecided++]);
                        break;
            }
        }
    }
    
    public void Swap(ref int a, ref int b)
    {
        var c = a; a = b; b = c;
    }

    static void Main()
    {
        var rand = new Random();
        var a = Enumerable.Repeat(1, 97).Select(x => rand.Next(3)).ToArray();
        Console.WriteLine(String.Join(
                    String.Empty, 
                    a));
        SortColors(a);
        Console.WriteLine(String.Join(
                    String.Empty, 
                    a));
    }
}

