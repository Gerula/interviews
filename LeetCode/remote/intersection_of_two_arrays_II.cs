//  https://leetcode.com/problems/intersection-of-two-arrays-ii/
//   Given two arrays, write a function to compute their intersection.
//
//   Example:
//   Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2, 2]. 
//  https://leetcode.com/submissions/detail/62129710/
//
//  Submission Details
//  60 / 60 test cases passed.
//      Status: Accepted
//      Runtime: 468 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    private Dictionary<int, int> ToDictionary(int[] nums)
    {
        return nums.Aggregate(
                    new Dictionary<int, int>(),
                    (acc, x) => {
                        if (!acc.ContainsKey(x)) {
                            acc[x] = 0;
                        }
                        
                        acc[x]++;
                        return acc;
                    });        
    }
    
    public int[] Intersect(int[] nums1, int[] nums2) {
        var a = ToDictionary(nums1);
        var b = ToDictionary(nums2);
        return a.Keys.Aggregate(
                        new List<int>(),
                        (acc, x) => {
                           acc.AddRange(b.ContainsKey(x) ? 
                                            Enumerable.Repeat(x, Math.Min(a[x], b[x])) :
                                            new int[0]);
                           return acc;
                        }).ToArray();
    }
}
