//  https://leetcode.com/problems/n-queens-ii/
//
//  Follow up for N-Queens problem.
//
//  Now, instead outputting board configurations, return the total number of distinct solutions.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  9 / 9 test cases passed.
    //      Status: Accepted
    //      Runtime: 72 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int TotalNQueens(int n) {
        return Total(0, n, new List<int>());
    }

    public int Total(int pos, int n, List<int> list)
    {
        if (pos == n)
        {
            return 1;
        }

        var result = 0;
        for (var i = 0; i < n; i++)
        {
            if (Valid(list, pos, i))
            {
                list.Add(i);
                result += Total(pos + 1, n, list);
                list.RemoveAt(list.Count - 1);
            }
        }

        return result;
    }

    public bool Valid(List<int> list, int level, int x)
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i] == x || level - i == Math.Abs(x - list[i]))
            {
                return false;
            }
        }

        return true;
    }

    static void Main() {
        Console.WriteLine(new Solution().TotalNQueens(4));
    }
}
