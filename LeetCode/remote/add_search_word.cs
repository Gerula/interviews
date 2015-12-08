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
public class WordDictionary {
    class Node
    {
        internal readonly Dictionary<char, Node> Next = new Dictionary<char, Node>();
        internal bool IsFinal = false;
    }

    private Node Root;

    public WordDictionary()
    {
        Root = new Node();
    }

    public void AddWord(String word) {
        var node = word.Aggregate(
                            Root,
                            (acc, x) => {
                                if (acc.Next.ContainsKey(x))
                                {
                                    return acc.Next[x];
                                }
                                
                                acc.Next[x] = new Node();
                                return acc.Next[x];
                            });
        node.IsFinal = true;
    }

    public bool Search(string word) {
        return Search(word, Root);
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
                   .Keys
                   .Select(x => Search(word.Substring(1), current.Next[x]))
                   .Aggregate(false, (acc, a) => acc || a);
        }

        if (!current.Next.ContainsKey(word.First()))
        {
            return false;
        }

        return Search(word.Substring(1), current.Next[word.First()]);
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

