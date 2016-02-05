//  https://leetcode.com/submissions/detail/52733436/

public class Solution {
    //  
    //  Submission Details
    //  67 / 67 test cases passed.
    //      Status: Accepted
    //      Runtime: 180 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int MaximalSquare(char[,] matrix) {
        var max = 0;
        var n = matrix.GetLength(0);
        var m = matrix.GetLength(1);
        var dp = new int[n, m];
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                if (matrix[i, j] != '1')
                {
                    continue;
                }
                
                var top = i > 0 ? dp[i - 1, j] : 0;
                var left = j > 0 ? dp[i, j - 1] : 0;
                var topLeft = i > 0 && j > 0 ? dp[i - 1, j - 1] : 0;
                dp[i, j] = Math.Min(Math.Min(top, left), topLeft) + 1;
                max = Math.Max(dp[i, j], max);
                if (max == 3)
                {
                    Console.WriteLine("{0} {1}", i, j);
                }
            }
        }
        
        return max * max;
    }
}
