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
using System.Text;

public class Solution {
    //  
    //  Submission Details
    //  37 / 37 test cases passed.
    //      Status: Accepted
    //      Runtime: 288 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  You are here!
    //  Your runtime beats 50.00% of csharp submissions.
    //
    //  Even Steven!!
    //
    // Key learning:
    // - the original algorithm was O(n^2)
    // - the optimized version is O(n x l x 27)
    public int LadderLength(string beginWord, string endWord, ISet<string> wordList) {
        wordList.Add(endWord);

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

            foreach (var x in GetVariants(current, wordList, visited))
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

    public IEnumerable<String> GetVariants(string word, ISet<string> wordList, ISet<string> visited)
    {
        StringBuilder next = new StringBuilder(word);
        for (var i = 0; i < word.Length; i++)
        {
            var c = next[i];
            for (var k = 'a'; k <= 'z'; k++)
            {
                if (next[i] == k)
                {
                    continue;
                }
                
                next[i] = k;
                string candidate = next.ToString();
                if (wordList.Contains(candidate) && !visited.Contains(candidate))
                {
                    yield return candidate;
                }
            }

            next[i] = c;
        }
    }
    
    //  It's regression, baby!
    //  https://leetcode.com/submissions/detail/61670477/
    //
    //  Submission Details
    //  37 / 37 test cases passed.
    //      Status: Accepted
    //      Runtime: 439 ms
    //          
    //          Submitted: 0 minutes ago
    public class Solution {
        public IEnumerable<String> Neighbors(string word, ISet<string> wordList) 
        {
            var sb = new StringBuilder(word);
            for (var i = 0; i < word.Length; i++)
            {
                for (var k = 'a'; k <= 'z'; k++)
                {
                    var aux = sb[i];
                    sb[i] = k;
                    if (wordList.Contains(sb.ToString()))
                    {
                        yield return sb.ToString();
                    }
                    
                    sb[i] = aux;
                }
            }
            
            yield break;
        }
    
        public int Unfold(string start, Dictionary<String, String> parents)
        {
            var count = 1;
            while (parents.ContainsKey(start)) 
            {
                count++;
                start = parents[start];
            }
            
            return count;
        }
    
        public int LadderLength(string beginWord, string endWord, ISet<string> wordList) {
            var visited = new HashSet<String>();
            var queue = new Queue<String>();
            var parent = new Dictionary<String, String>();
            visited.Add(beginWord);
            wordList.Add(endWord);
            queue.Enqueue(beginWord);
            
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current == endWord)
                {
                    return Unfold(current, parent);
                    break;
                }
                
                foreach (var x in Neighbors(current, wordList).Where(y => !visited.Contains(y)))
                {
                    Console.WriteLine("{0} {1}", current, x);
                    parent[x] = current;
                    visited.Add(x);
                    queue.Enqueue(x);
                }
            }
            
            return 0;
        }
    } 

    static void Main()
    {
        var solution = new Solution();
        Console.WriteLine(solution.LadderLength("hit", "cog", new HashSet<String> { "hot", "dot", "dog", "lot", "log", "sux" }));
    }
}
