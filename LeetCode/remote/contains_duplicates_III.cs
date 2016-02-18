//  https://leetcode.com/problems/contains-duplicate-iii/
//
//  Given an array of integers,
//  find out whether there are two distinct indices i and j in the array such that the difference
//  between nums[i] and nums[j] is at most t and the difference between i and j is at most k. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    class Dequeue
    {
        private LinkedList<int> storage = new LinkedList<int>();
        
        public Dequeue()
        {
            Empty = true;
        }
        
        public void Add(int x, Func<int, int, bool> comparer)
        {
            while (storage.Count > 0 && comparer(storage.Last(), x))
            {
                storage.RemoveLast();
            }
            
            storage.AddLast(x);
            Empty = false;
        }
        
        public void Remove(int x)
        {
            if (storage.Count > 0 && storage.First() == x)
            {
                storage.RemoveFirst();
            }
            
            Empty = storage.Count == 0;
        }
        
        public int Head {
            get {
                return storage.First();
            }
        }
        
        public bool Empty { 
            get; 
            private set; 
        }
    }
    
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        var max = new Dequeue();
        var min = new Dequeue();
        for (var i = 0; i < Math.Min(k, nums.Length); i++)
        {
            max.Add(nums[i], (a, b) => a >= b);
            min.Add(nums[i], (a, b) => a < b);
        }

        if (!max.Empty && !min.Empty && max.Head - min.Head <= t)
        {
            return true;
        }
        
        for (var i = k; i < nums.Length; i++)
        {
            max.Add(nums[i], (a, b) => a >= b);
            min.Add(nums[i], (a, b) => a < b);
            max.Remove(nums[i - k]);
            min.Remove(nums[i - k]);
            
            if (!max.Empty && !min.Empty && max.Head - min.Head <= t)
            {
                return true;
            }
        }
        
        return false;
    }

    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        var set = new SortedDictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (set.Any() && set.Keys.Last() - set.Keys.First() <= t)
            {
                return true;
            }

            if (!set.ContainsKey(nums[i]))
            {
                set[nums[i]] = 0;
            }

            set[nums[i]]++;
            if (i >= k) 
            {
                set[nums[i - k]]--;

                if (set[nums[i - k]] == 0)
                {
                    set.Remove(nums[i - k]);
                }
            }
        }

        return false;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { 1, 2, 3, 4, 5, 6 }, 4, 3 ));
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { 1, 2, 3, 4, 5, 6 }, 4, -1 ));
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { 0 }, 0, 0 ));
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { -3, 3 }, 2, 4 ));
    }
}
