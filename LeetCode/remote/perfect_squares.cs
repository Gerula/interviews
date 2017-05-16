//  https://leetcode.com/problems/perfect-squares/
//
//   Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
//
//   For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    // 
    // Submission Details
    // 600 / 600 test cases passed.
    //  Status: Accepted
    //  Runtime: 180 ms
    //      
    //      Submitted: 0 minutes ago
    //
    public int NumSquares(int n) {
        var dp = new int[n + 1];

        for (var i = 1; i <= n; i++)
        {
            dp[i] = int.MaxValue;
            for (var j = 1; j * j <= i; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
            }
        }

        return dp[n];
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.NumSquares(4));
        Console.WriteLine(s.NumSquares(12));
        Console.WriteLine(s.NumSquares(13));
        Console.WriteLine(s.NumSquares(1535));
    }
}

// It's evolution, baby!
// TLE:
public class Solution {
    public int NumSquares(int n) {
        if (n < 2)
        {
            return n;
        }
        
        return Enumerable
               .Range(1, (int) Math.Sqrt(n))
               .Select(x => 1 + NumSquares(n - x * x))
               .Min();
    }
}

//  Output limit exceeded
public class Solution {
    public int NumSquares(int n, Dictionary<int, int> hash = null) {
        if (hash == null)
        {
            hash = new Dictionary<int, int>();
        }
        
        if (n < 2)
        {
            return n;
        }
        
        if (hash.ContainsKey(n))
        {
            return hash[n];
        }
        
        hash[n] = Enumerable
                  .Range(1, (int) Math.Sqrt(n))
                  .Select(x => 1 + NumSquares(n - x * x, hash))
                  .Min();
        return hash[n];
    }
}

//  https://leetcode.com/submissions/detail/58410276/
//
//  Submission Details
//  600 / 600 test cases passed.
//      Status: Accepted
//      Runtime: 1100 ms
//          
//          Submitted: 1 minute ago
//
public class Solution {
    public int NumSquares(int n, Dictionary<int, int> hash = null) {
        var dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        for (var i = 2; i <= n; i++)
        {
            dp[i] = Enumerable
                    .Range(1, (int) Math.Sqrt(i))
                    .Select(x => 1 + dp[i - x * x])
                    .Min();
        }
        
        return dp[n];
    }
}

//  This is bullshit
//  https://leetcode.com/submissions/detail/66957547/
//
//  Submission Details
//  600 / 600 test cases passed.
//      Status: Accepted
//      Runtime: 180 ms
//          
//          Submitted: 1 minute ago
public class Solution {
    public int NumSquares(int n) {
        var minSquares = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        minSquares[0] = 0;
        minSquares[1] = 1;
        
        for (var i = 2; i <= n; i++) {
            for (var j = 1; j * j <= i; j++) {
                minSquares[i] = Math.Min(minSquares[i], 1 + minSquares[i - j * j]);
            }
        }
        
        return minSquares[n];
    }
}
    
