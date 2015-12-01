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

using System;

public class Solution {
    public int NumTrees(int n) {
        if (n < 2) 
        {
            return 1;
        }
        
        var count = 0;
        for (var i = 1; i <= n; i++)
        {
            count += NumTrees(i - 1) * NumTrees(n - i);
        }

        return count;
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.NumTrees(3));
        Console.WriteLine(c.NumTrees(19));
    }
}
