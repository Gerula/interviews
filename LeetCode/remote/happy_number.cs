//  https://leetcode.com/problems/happy-number/
//
//  Write an algorithm to determine if a number is "happy".
//
//  A happy number is a number defined by the following process: Starting with any positive integer,
//  replace the number by the sum of the squares of its digits,
//  and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
//  Those numbers for which this process ends in 1 are happy numbers.

public class Solution {
    //  
    //  Submission Details
    //  400 / 400 test cases passed.
    //      Status: Accepted
    //      Runtime: 72 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public bool IsHappy(int n) {
        var seen = new HashSet<int>();
        while (!seen.Contains(n) && n != 1)
        {
            seen.Add(n);
            n = n.ToString().Aggregate(0, (acc, x) => acc + (int) Math.Pow(int.Parse(x.ToString()), 2));
        }
        
        return n == 1;
    }
}
