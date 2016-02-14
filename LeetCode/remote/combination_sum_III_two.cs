//  https://leetcode.com/problems/combination-sum-iii/
//
//  Find all possible combinations of k numbers that add up to a number n,
//  given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.
//
//  Ensure that numbers within the set are sorted in ascending order.
//
//  Tried to do it in Ruby but the whole fucking thing sucks when it comes to arrays and flattening et al.
//  This is TLE, but this is the solution. C# is generally slower in the OJ.

public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var result = new List<IList<int>>();
        if (k == 0 || n <= 0)
        {
            return result;
        }
        
        if (k == 1)
        {
            return n < 9 ? new List<IList<int>> { new List<int> { n }} : result;
        }
        
        result.AddRange(Enumerable
                        .Range(1, 9)
                        .SelectMany(x => CombinationSum3(k - 1, n - x)
                                         .Where(y => y.Count == k - 1 && y[0] > x)
                                         .Select(y => new List<int> { x }
                                                     .Concat(y)
                                                     .ToList()))
                        .ToList());
        return result;
    }
}
