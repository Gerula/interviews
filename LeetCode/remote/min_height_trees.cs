// https://leetcode.com/problems/minimum-height-trees/
//
//  For a undirected graph with tree characteristics, we can choose any node as the root.
//  The result graph is then a rooted tree. Among all possible rooted trees,
//  those with minimum height are called minimum height trees (MHTs). Given such a graph,
//  write a function to find all the MHTs and return a list of their root labels in ascending order.
//
// 
// Submission Details
// 66 / 66 test cases passed.
//  Status: Accepted
//  Runtime: 676 ms
//      
//      Submitted: 0 minutes ago

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[,] edges) {
        var hash = new Dictionary<int, HashSet<int>>();
        var degrees = new Dictionary<int, int>();
        var unVisited = new HashSet<int>();
        for (var i = 0; i < edges.GetLength(0); i++)
        {
            var x = edges[i, 0];
            var y = edges[i, 1];
            if (!hash.ContainsKey(x))
            {
                hash[x] = new HashSet<int>();
                degrees[x] = 0;
            }

            if (!hash.ContainsKey(y))
            {
                hash[y] = new HashSet<int>();
                degrees[y] = 0;
            }

            hash[x].Add(y);
            hash[y].Add(x);
            unVisited.Add(x);
            unVisited.Add(y);
            degrees[x]++;
            degrees[y]++;
        }

        if (!hash.Any())
        {
            return Enumerable.Range(0, n).ToList();
        }

        var currentLevel = hash.Keys.Where(x => hash[x].Count == 1).ToList();
        while (unVisited.Count > 2)
        {
            var nextLevel = new List<int>();
            foreach (var node in currentLevel)
            {
                unVisited.Remove(node);
                foreach (var neighbor in hash[node].Where(x => unVisited.Contains(x)))
                {
                    degrees[neighbor]--;
                    if (degrees[neighbor] == 1)
                    {
                        nextLevel.Add(neighbor);
                    }
                }
            }

            currentLevel = nextLevel;
        }

        return currentLevel;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                            ", ", 
                            new Solution()
                                .FindMinHeightTrees(4, new int[,] {
                                    {1, 0},
                                    {1, 2},
                                    {1, 3} // Yeah, great work leetcode. This is a way more smarter way to hold a graph
                                })));

        Console.WriteLine(String.Join(
                            ", ", 
                            new Solution()
                                .FindMinHeightTrees(6, new int[,] {
                                    {0, 1},
                                    {0, 2},
                                    {0, 3},
                                    {3, 4},
                                    {4, 5}
                                })));

        Console.WriteLine(String.Join(
                            ", ", 
                            new Solution()
                                .FindMinHeightTrees(1, new int[0, 0])));
    }
}
