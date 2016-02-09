//  https://leetcode.com/problems/maximum-gap/
//
//  bla bla bla

public class Solution {
    //  https://leetcode.com/submissions/detail/52998001/
    //
    //
    //  Submission Details
    //  17 / 17 test cases passed.
    //      Status: Accepted
    //      Runtime: 212 ms
    //          
    //          Submitted: 0 minutes ago
    //
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
        var dictionary = nums.Aggregate(
                new SortedDictionary<int, List<int>>(),
                (acc, x) => {
                    if (!acc.ContainsKey(x))
                    {
                        acc[x] = new List<int>();
                    }
                    
                    acc[x].Add(x);
                    return acc;
                }
            );
        return dictionary
               .Keys
               .Aggregate(
                   new List<int>(),
                   (acc, x) => {
                        acc.AddRange(dictionary[x]);
                        return acc;
                   })
               .ToArray();
    }
}
