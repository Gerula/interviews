//  https://leetcode.com/problems/triangle/
//
//  Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
//
//  For example, given the following triangle
//
//  [
//       [2],
//       [3,4],
//       [6,5,7],
//       [4,1,8,3]
//  ]
//
//  The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11). 

public class Solution {
    //  
    //  Submission Details
    //  43 / 43 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52313750/
    public int MinimumTotal(IList<IList<int>> triangle) {
        return triangle
               .Reverse()
               .Skip(1)
               .Aggregate(
                   triangle.Last(),
                   (acc, x) => acc
                               .Zip(acc.Skip(1), (a, b) => Math.Min(a, b))
                               .Zip(x, (a, b) => a + b)
                               .ToList())
               .First();
    }
}

//  LOL
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        return triangle
               .Reverse()
               .Aggregate((acc, x) => {
                   return x
                          .Zip(acc
                              .Zip(acc.Skip(1),
                                    (a, b) => Math.Min(a, b)),
                              (a, b) => a + b)
                          .ToList();
               })
               .First();
    }
}

//  Kekekeke
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        return triangle
               .Reverse()
               .Aggregate((acc, x) => {
                   return x.Zip(
                       acc.Zip(
                           acc.Skip(1), 
                           (a, b) => Math.Min(a, b)),
                       (y, z) => y + z).ToList();
               })
               .First();
    }
}
