//  https://leetcode.com/problems/dungeon-game/
//
//  The demons had captured the princess (P) and imprisoned her in the bottom-right corner of a dungeon.
//  The dungeon consists of M x N rooms laid out in a 2D grid.
//  Our valiant knight (K) was initially positioned in the top-left room and must fight
//  his way through the dungeon to rescue the princess.
//
//  The knight has an initial health point represented by a positive integer.
//  If at any point his health point drops to 0 or below, he dies immediately.
//
//  Some of the rooms are guarded by demons, so the knight loses health (negative integers)
//  upon entering these rooms; other rooms are either empty (0's)
//  or contain magic orbs that increase the knight's health (positive integers).
//
//  In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step. 
// 
//
// Submission Details
// 44 / 44 test cases passed.
//  Status: Accepted
//  Runtime: 168 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class Solution {
    public int CalculateMinimumHP(int[,] dungeon) {
        var n = dungeon.GetLength(0);
        var m = dungeon.GetLength(1);
        var dp = new int[n + 1, m + 1];
        for (var i = 0; i < n; i++) { dp[i, m] = int.MaxValue; }
        for (var j = 0; j < m; j++) { dp[n, j] = int.MaxValue; }
        dp[n, m - 1] = 1;
        dp[n - 1, m] = 1;
        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = m - 1; j >= 0 ; j--)
            {
                var energy = Math.Min(dp[i, j + 1], dp[i + 1, j]) - dungeon[i, j];
                dp[i, j] = energy <= 0 ? 1 : energy;
            }
        }

        return dp[0, 0];
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.CalculateMinimumHP(new [,] {
                        { -2, -3, 3 },
                        { -5, -10, 1 },
                        {10, 30, -5}
                    }));
        Console.WriteLine(s.CalculateMinimumHP(new [,] {
                        { 2 },
                        { 1 }
                    }));
        Console.WriteLine(s.CalculateMinimumHP(new [,] {
                        { -3, 5 }
                    }));
        Console.WriteLine(s.CalculateMinimumHP(new [,] {
                        { 0, -3 }
                    }));
    }
}
