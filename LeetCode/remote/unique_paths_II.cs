//  https://leetcode.com/problems/unique-paths-ii/
//
//  Follow up for "Unique Paths":
//
//  Now consider if some obstacles are added to the grids. How many unique paths would there be?
//
//  An obstacle and empty space is marked as 1 and 0 respectively in the grid.

//  
//  Submission Details
//  43 / 43 test cases passed.
//      Status: Accepted
//      Runtime: 164 ms
//          
//          Submitted: 0 minutes ago
//
//  https://leetcode.com/submissions/detail/53165095/

public class Solution {
    public int UniquePathsWithObstacles(int[,] obstacleGrid) {
        var n = obstacleGrid.GetLength(0);
        var m = obstacleGrid.GetLength(1);
        var dp = new int[n, m];
        if (obstacleGrid[0, 0] == 1)
        {
            return 0;
        }
        
        dp[0, 0] = 1;
        
        for (var i = 1; i < n && obstacleGrid[i, 0] == 0; i++)
        {
            dp[i, 0] = dp[i - 1, 0];
        }
        
        for (var i = 1; i < m && obstacleGrid[0, i] == 0; i++)
        {
            dp[0, i] = dp[0, i - 1];
        }
        
        for (var i = 1; i < n; i++)
        {
            for (var j = 1; j < m; j++)
            {
                if (obstacleGrid[i, j] == 1)
                {
                    continue;
                }
                
                dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
            }
        }
        
        return dp[n - 1, m - 1];
    }
}
