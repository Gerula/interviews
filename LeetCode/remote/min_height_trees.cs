// https://leetcode.com/problems/minimum-height-trees/
//
//  For a undirected graph with tree characteristics, we can choose any node as the root.
//  The result graph is then a rooted tree. Among all possible rooted trees,
//  those with minimum height are called minimum height trees (MHTs). Given such a graph,
//  write a function to find all the MHTs and return a list of their root labels in ascending order.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[,] edges) {
        var hash = new Dictionary<int, HashSet<int>>();
        for (var i = 0; i < edges.GetLength(0); i++)
        {
            if (!hash.ContainsKey(edges[i, 0]))
            {
                hash[edges[i, 0]] = new HashSet<int>();
            }

            if (!hash.ContainsKey(edges[i, 1]))
            {
                hash[edges[i, 1]] = new HashSet<int>();
            }

            hash[edges[i, 0]].Add(edges[i, 1]);
            hash[edges[i, 1]].Add(edges[i, 0]);
        }

        if (!hash.Any())
        {
            return Enumerable.Range(0, n).ToList();
        }

        var candidates = Enumerable
                         .Range(0, n)
                         .Where(x => hash[x].Count > 1);

        var min = int.MaxValue;
        if (!candidates.Any())
        {
            candidates = Enumerable.Range(0, n);
        }

        var counts = candidates.Select(x => {
                var queue = new Queue<int>();
                var visited = new BitArray(n, false);
                var levels = 1;
                var currentLevel = 1;
                var nextLevel = 0;
                queue.Enqueue(x);
                visited[x] = true;
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    currentLevel--;
                    foreach (var i in hash[current].Where(z => !visited[z]))
                    {
                        visited[i] = true;
                        nextLevel++;
                        queue.Enqueue(i);
                    }
                    
                    if (currentLevel == 0)
                    {
                        levels++;
                        currentLevel = nextLevel;
                        nextLevel = 0;
                    }
                }

                min = Math.Min(min, levels);
                return new { Node = x, Levels = levels };
        });

        return counts
               .Where(x => x.Levels == min)
               .Select(y => y.Node)
               .ToList();
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
                                .FindMinHeightTrees(1, new int[0, 0])));
    }
}
