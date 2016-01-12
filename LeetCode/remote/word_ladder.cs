//  https://leetcode.com/problems/word-ladder/
//
//   Given two words (beginWord and endWord), and a dictionary's word list,
//   find the length of shortest transformation sequence from beginWord to endWord, such that:
//
//   Only one letter can be changed at a time
//   Each intermediate word must exist in the word list
//
//   For example,
//
//   Given:
//   beginWord = "hit"
//   endWord = "cog"
//   wordList = ["hot","dot","dog","lot","log"]
//
//   As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
//   return its length 5. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int LadderLength(string beginWord, string endWord, ISet<string> wordList) {
        wordList.Add(beginWord);
        wordList.Add(endWord);

        var adjacency = wordList.Aggregate(
                            new Dictionary<String, HashSet<String>>(),
                            (agg, x) => {
                                agg[x] = new HashSet<String>(wordList.Where(y => OneEdit(x, y)));
                                return agg;
                            });

        var queue = new Queue<String>();
        var visited = new HashSet<String>();
        var currentLevel = 1;
        var nextLevel = 0;
        var levels = 1;
        queue.Enqueue(beginWord);
        visited.Add(beginWord);
        while (queue.Any())
        {
            var current = queue.Dequeue();
            currentLevel--;
            foreach (var x in adjacency[current].Where(y => !visited.Contains(y)))
            {
                if (x == endWord)
                {
                    return levels + 1;
                }

                visited.Add(x);
                queue.Enqueue(x);
                nextLevel++;
            }

            if (currentLevel == 0)
            {
                levels++;
                currentLevel = nextLevel;
                nextLevel = 0;
            }
        }

        return -1;
    }

    public static bool OneEdit(String first, String second)
    {
        return first
               .Zip(second, (x, y) => x != y)
               .Count(x => x) == 1;
    }
    
    static void Main()
    {
        var solution = new Solution();
        Console.WriteLine(solution.LadderLength("hit", "cog", new HashSet<String> { "hot", "dot", "dog", "lot", "log", "sux" }));
    }
}
