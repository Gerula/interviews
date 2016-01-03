//  https://leetcode.com/problems/course-schedule-ii/
//
//   There are a total of n courses you have to take, labeled from 0 to n - 1.
//
//   Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
//
//   Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
//
//   There may be multiple correct orders, you just need to return one of them. If it is impossible to finish all courses, return an empty array. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] FindOrder(int numCourses, int[,] prerequisites) {
        var adjacency = new Dictionary<int, HashSet<int>>();
        for (var i = 0; i < prerequisites.GetLength(0); i++)
        {
            if (!adjacency.ContainsKey(prerequisites[i, 0]))
            {
                adjacency[prerequisites[i, 0]] = new HashSet<int>();
            }

            adjacency[prerequisites[i, 0]].Add(prerequisites[i, 1]);
        }

        var stack = new Stack<int>();
        var visited = new HashSet<int>();
        var visiting = new HashSet<int>();
        for (var i = 0; i < numCourses; i++)
        {
            if (!Dfs(i, adjacency, visited, visiting, stack))
            {
                return new int[0];
            }
        }

        return stack.Reverse().ToArray();
    }

    public bool Dfs(int current,
                    Dictionary<int, HashSet<int>> adjacency,
                    HashSet<int> visited,
                    HashSet<int> visiting,
                    Stack<int> stack)
    {
        if (visited.Contains(current))
        {
            return true;
        }

        visited.Add(current);
        visiting.Add(current);
        var result = true;
        if (adjacency.ContainsKey(current))
        {
            result = adjacency[current]
                        .Where(x => !visited.Contains(x))
                        .Aggregate(true, (acc, x) => {
                            return !visiting.Contains(x) && Dfs(x, adjacency, visited, visiting, stack);
                        });
        }

        visiting.Remove(current);
        return result;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(String.Join(", ", s.FindOrder(2, new [,] { {1, 0} })));
        Console.WriteLine(String.Join(", ", s.FindOrder(4, new [,] { {1, 0}, {2, 0}, {3, 1}, {3, 2} })));
    }
}
