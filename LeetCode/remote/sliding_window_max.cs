//  https://leetcode.com/problems/sliding-window-maximum/
//
//  Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.
//
//  For example,
//  Given nums = [1,3,-1,-3,5,3,6,7], and k = 3.
//
//  Window position                Max
//  ---------------               -----
//  [1  3  -1] -3  5  3  6  7       3
//  1 [3  -1  -3] 5  3  6  7       3
//  1  3 [-1  -3  5] 3  6  7       5
//  1  3  -1 [-3  5  3] 6  7       5
//  1  3  -1  -3 [5  3  6] 7       6
//  1  3  -1  -3  5 [3  6  7]      7
//
//  Therefore, return the max sliding window as [3,3,5,5,6,7].

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public class Dequeue 
    {
        private LinkedList<int> data;

        public Dequeue()
        {
            data = new LinkedList<int>();
        }

        public void Add(int num)
        {
            while (data.Count != 0 && data.Last.Value < num)
            {
                data.RemoveLast();
            }

            data.AddLast(num);
        }

        public void Remove(int num)
        {
            if (data.First.Value == num)
            {
                data.RemoveFirst();
            }
        }

        public int Max()
        {
            return data.First.Value;
        }
    }

    //  
    //  Submission Details
    //  18 / 18 test cases passed.
    //      Status: Accepted
    //      Runtime: 564 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52430350/
    //
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var n = nums.Length;
        if (n == 0)
        {
            return new int[0];
        }

        var result = new int[n - k + 1];
        var dequeue = new Dequeue();
        for (var i = 0; i < n; i++)
        {
            dequeue.Add(nums[i]);
            if (i >= k - 1)
            {
                result[i - k + 1] = dequeue.Max();
                dequeue.Remove(nums[i - k + 1]);
            }
        }

        return result;
    }

    public int[] MaxSlidingWindow2(int[] nums, int k) {
        return nums.Length == 0 ? 
               new int[0] :
               Enumerable
               .Range(0, nums.Length - k + 1)
               .Select(x => nums
                            .Skip(x)
                            .Take(k)
                            .Max())
               .ToArray();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().MaxSlidingWindow(new [] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3)));
        Console.WriteLine(String.Join(", ", new Solution().MaxSlidingWindow(new [] { 7, 2, 4 }, 2)));
        Console.WriteLine(String.Join(", ", new Solution().MaxSlidingWindow2(new [] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3)));
        Console.WriteLine(String.Join(", ", new Solution().MaxSlidingWindow2(new [] { 7, 2, 4 }, 2)));
    }
}
