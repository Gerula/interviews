//  https://leetcode.com/problems/maximum-gap/
//
//  bla bla bla

public class Solution {
    public int MaximumGap(int[] nums) {
        if (nums.Length < 2)
        {
            return 0;
        }
        
        var sorted = Count(nums);
        return sorted
               .Zip(
                  sorted
                  .Skip(1),
                  (a, b) => b - a)
               .Max();
    }
    
    public int[] Count(int[] nums)
    {
        var min = int.MaxValue;
        var max = int.MinValue;
        var dictionary = nums.Aggregate(
                new Dictionary<int, List<int>>(),
                (acc, x) => {
                    if (!acc.ContainsKey(x))
                    {
                        acc[x] = new List<int>();
                    }
                    
                    acc[x].Add(x);
                    min = Math.Min(min, x);
                    max = Math.Max(max, x);
                    return acc;
                }
            );
        return Enumerable
               .Range(min, (max - min) + 1)
               .Aggregate(
                   new List<int>(),
                   (acc, x) => {
                        if (dictionary.ContainsKey(x))
                        {
                            acc.AddRange(dictionary[x]);
                        }
                        
                        return acc;
                   })
               .ToArray();
    }
}
