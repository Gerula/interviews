// Given n, how many structurally unique BST's (binary search trees) that store values 1...n?
//
// For example,
// Given n = 3, there are a total of 5 unique BST's.
//
//    1         3     3      2      1
//     \       /     /      / \      \
//      3     2     1      1   3      2
//     /     /       \                 \
//    2     1         2                 3
//
// 
// Submission Details
// 19 / 19 test cases passed.
//  Status: Accepted
//  Runtime: 56 ms
//      
//      Submitted: 0 minutes ago
//

using System;
using System.Linq;

public class Solution {
    public int NumTrees(int n) {
        var cache = new int[n + 2];
        cache[0] = cache[1] = 1;
        return NumTree(n, cache);
    }

    // 
    // Submission Details
    // 19 / 19 test cases passed.
    //  Status: Accepted
    //  Runtime: 56 ms
    //      
    //      Submitted: 0 minutes ago
    public int NumTreees(int n)
    {
        var dp = new int[n + 2];
        dp[0] = dp[1] = 1;
        for (var i = 2; i <= n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                dp[i] += dp[j] * dp[i - j - 1];
            }
        }

        return dp[n];
    }

    public int NumTree(int n, int[] cache)
    {
        if (cache[n] != 0)
        {
            return cache[n];
        }

        cache[n] = Enumerable
                    .Range(1, n)
                    .Aggregate(0, (acc, x) => {
                                return acc + NumTree(x - 1, cache) * NumTree(n - x, cache);
                            });
        
        return cache[n];
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.NumTrees(3));
        Console.WriteLine(c.NumTrees(19));
        Console.WriteLine(c.NumTreees(3));
        Console.WriteLine(c.NumTreees(19));
    }
}
