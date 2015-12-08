//  https://leetcode.com/problems/add-and-search-word-data-structure-design/
//   Design a data structure that supports the following two operations:
//
//   void addWord(word)
//   bool search(word)
//
//   search(word) can search a literal word or a regular expression string containing only letters a-z or .. A
//   . means it can represent any one letter.

using System;
using System.Collections.Generic;
using System.Linq;

// HAHA
// Submission Result: Memory Limit Exceeded 

// 
// Submission Details
// 13 / 13 test cases passed.
//  Status: Accepted
//  Runtime: 668 ms
//      
//      Submitted: 0 minutes ago
//
//      Fixed it by chaning the Dictionary to an Array - less overhead much efficient.
public class WordDictionary {
    class Node
    {
        internal readonly Node[] Next = new Node[27];
        internal bool IsFinal = false;
    }

    private Dictionary<int, Node> Roots = new Dictionary<int, Node>();

    public void AddWord(String word) {
        if (!Roots.ContainsKey(word.Length))
        {
            Roots[word.Length] = new Node();
        }

        var Root = Roots[word.Length];
        var node = word.Aggregate(
                            Root,
                            (acc, x) => {
                                var idx = x - 'a';
                                if (acc.Next[idx] != null)
                                {
                                    return acc.Next[idx];
                                }
                                
                                acc.Next[idx] = new Node();
                                return acc.Next[idx];
                            });
        node.IsFinal = true;
    }

    public bool Search(string word) {
        if (!Roots.ContainsKey(word.Length))
        {
            return false;
        }

        return Search(word, Roots[word.Length]);
    }

    private bool Search(string word, Node current)
    {
        if (word.Length == 0)
        {
            return current.IsFinal;
        }

        if (word.First() == '.')
        {
            return current
                   .Next
                   .Where(node => node != null)
                   .Select(x => Search(word.Substring(1), x))
                   .Aggregate(false, (acc, a) => acc || a);
        }

        var idx = word.First() - 'a';
        if (current.Next[idx] == null)
        {
            return false;
        }

        return Search(word.Substring(1), current.Next[idx]);
    }
}

class Program
{
    static void Main()
    {
        WordDictionary wordDictionary = new WordDictionary();
        wordDictionary.AddWord("bad");
        wordDictionary.AddWord("dad");
        wordDictionary.AddWord("mad");
        Console.WriteLine(wordDictionary.Search("pad"));
        Console.WriteLine(wordDictionary.Search("bad"));
        Console.WriteLine(wordDictionary.Search(".ad"));
        Console.WriteLine(wordDictionary.Search("b.."));
    }
}

