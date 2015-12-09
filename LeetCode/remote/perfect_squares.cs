//  https://leetcode.com/problems/perfect-squares/
//
//   Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
//
//   For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  Time Limit Exceeded 
    public int NumSquares(int n) {
        var squares = Enumerable.Range(1, (int)Math.Sqrt(n)).Select(x => x * x).ToArray();
        var queue = new List<int>();
        
        if (n == squares.Last())
        {
            return 1;
        }

        var level = 0;
        queue.Add(n);
        var found = false;
        while (!found)
        {
            level++;
            var temp = new List<int>();
            foreach (var x in queue)
            {
                foreach (var candidate in squares.Where(y => y <= x).Select(y => x - y))
                {
                    temp.Add(candidate);
                    if (candidate == 0)
                    {
                        found = true;
                        break;
                    }
                }
            }

            queue = temp;
        }

        return level;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.NumSquares(4));
        Console.WriteLine(s.NumSquares(12));
        Console.WriteLine(s.NumSquares(13));
    }
}
