//  https://leetcode.com/problems/number-of-islands/
//
//  Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.
//  An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
//  You may assume all four edges of the grid are all surrounded by water.

public class Solution {
    //  https://leetcode.com/submissions/detail/52480895/
    //
    //
    //  Submission Details
    //  45 / 45 test cases passed.
    //      Status: Accepted
    //      Runtime: 172 ms
    //          
    //          Submitted: 1 minute ago
    //
    public int NumIslands(char[,] grid) {
        var result = 0;
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == '0')
                {
                    continue;
                }
                
                result++;
                var stack = new Stack<Tuple<int, int>>();
                stack.Push(Tuple.Create(i, j));
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    if (0 > current.Item1 || current.Item1 >= grid.GetLength(0) ||
                        0 > current.Item2 || current.Item2 >= grid.GetLength(1) ||
                        grid[current.Item1, current.Item2] == '0')
                        {
                            continue;
                        }
                    
                    grid[current.Item1, current.Item2] = '0';
                    stack.Push(Tuple.Create(current.Item1 + 1, current.Item2));
                    stack.Push(Tuple.Create(current.Item1 - 1, current.Item2));
                    stack.Push(Tuple.Create(current.Item1, current.Item2 + 1));
                    stack.Push(Tuple.Create(current.Item1, current.Item2 - 1));
                }
            }
        }
        
        return result;
    }
}
