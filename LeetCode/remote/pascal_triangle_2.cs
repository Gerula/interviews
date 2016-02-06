//  https://leetcode.com/problems/pascals-triangle-ii/
//
//  Given an index k, return the kth row of the Pascal's triangle.
//
//  For example, given k = 3,
//  Return [1,3,3,1]. 

//  https://leetcode.com/submissions/detail/52811939/
//
//
//  Submission Details
//  34 / 34 test cases passed.
//      Status: Accepted
//      Runtime: 428 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public IList<int> GetRow(int rowIndex) {
        return Enumerable
               .Range(1, rowIndex)
               .Aggregate(
                   new List<int> { 1 },
                   (acc, x) => new List<int> { 1 }
                               .Concat(acc.Zip(acc.Skip(1), (a, b) => a + b))
                               .Concat(new List<int> { 1 })
                               .ToList());
    }
}
