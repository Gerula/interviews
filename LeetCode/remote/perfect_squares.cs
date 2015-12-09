//  https://leetcode.com/problems/perfect-squares/
//
//   Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
//
//   For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  Memory limit exceeded
    public int NumSquares(int n) {
        var squares = Enumerable.Range(1, (int)Math.Sqrt(n)).Select(x => x * x).ToArray();
        var queue = new Queue<int>();
        squares.ToList().ForEach(x => queue.Enqueue(x));
        
        if (n == squares.Last())
        {
            return 1;
        }

        var currentLevelCount = squares.Length;
        var nextLevelCount = 0;
        var currentLevel = 1;
        var found = false;
        while (queue.Count > 0 && !found)
        {
            var item = queue.Dequeue();
            currentLevelCount--;
            foreach (var square in squares.Where(x => x + item <= n))
            {
                var sum = square + item;
                if (sum == n)
                {
                    currentLevel++;
                    found = true;
                    break;
                }
                
                queue.Enqueue(sum);
                nextLevelCount++;
            }

            if (currentLevelCount == 0)
            {
                currentLevel++;
                currentLevelCount = nextLevelCount;
                nextLevelCount = 0;
            }
        }

        return currentLevel;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.NumSquares(4));
        Console.WriteLine(s.NumSquares(12));
        Console.WriteLine(s.NumSquares(13));
    }
}
