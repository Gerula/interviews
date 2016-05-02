//  https://leetcode.com/problems/top-k-frequent-elements/
//   Given a non-empty array of integers, return the k most frequent elements.
//
//   For example,
//   Given [1,1,1,2,2,3] and k = 2, return [1,2]. 
//
//   https://leetcode.com/submissions/detail/60532923/
//
//   Submission Details
//   20 / 20 test cases passed.
//      Status: Accepted
//      Runtime: 560 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public IList<int> TopKFrequent(int[] nums, int k) {
        var frequencies = nums.Aggregate(
            new Dictionary<int, int>(),
            (acc, x) => {
               if (!acc.ContainsKey(x))
               {
                   acc[x] = 0;
               }
               
               acc[x]++;
               return acc;
            });
        
        var frequencyList = nums.Aggregate(
            new Dictionary<int, HashSet<int>>(),
            (acc, x) => {
                if (!acc.ContainsKey(frequencies[x]))
                {
                    acc[frequencies[x]] = new HashSet<int>();
                }
                
                acc[frequencies[x]].Add(x);
                return acc;
            });
        
        return Enumerable
               .Range(0, nums.Length + 1)
               .Reverse()
               .Select(x => frequencyList.ContainsKey(x) ? frequencyList[x] : null)
               .Aggregate(
                   new List<int>(),
                   (acc, x) => {
                       if (x == null)
                       {
                           return acc;
                       }
                       
                       acc.AddRange(x.ToList());
                       return acc;
                   })
               .Take(k)
               .ToList();
    }
}
