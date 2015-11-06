// http://careercup.com/question?id=5651322294501376
//
// Given an infinite stream of characters and a list L of strings,
// create a function that calls an external API when a word in L is recognized during the processing of the stream.
//
// Example:
// L = { "ok", "test", "one", "try", "trying" }
// Stream = { 'a', 'b', 'c', 'o', 'k', 'd', 'e', 'f', 't', 'r', 'y', 'i', 'n', 'g' }
//
// Call a function whenever a letter is encountered which finishes a word.
//

using System;
using System.Collections.Generic;
using System.Linq;

class TrieNode 
{
    public readonly Dictionary<char, TrieNode> Next = new Dictionary<char, TrieNode>();
    public bool IsWord { get; set; }
    public String Word { get; set; }

    public void Add(String s) 
    {
        this.AddWord(s, s);
    }

    private void AddWord(String s, String word)
    {
        var c = s[0];
        if (!this.Next.ContainsKey(c))
        {
            this.Next[c] = new TrieNode();
        }

        if (s.Length == 1)
        {
            this.Next[c].IsWord = true;
            this.Next[c].Word = word;
            return;
        }

        this.Next[c].AddWord(s.Substring(1), word);
    }

    public TrieNode GetNext(char c)
    {
        if (this.Next.ContainsKey(c))
        {
            return Next[c];
        }

        return null;
    }

    public override String ToString()
    {
        return String.Format(
                "[{0} | {1} | {2}]",
                String.Join(
                    ", ",
                    Next.Select(x => String.
                                        Format("{0} => {1}", 
                                            x.Key,
                                            x.Value.ToString()))),
                IsWord,
                Word);
    }
}

static class Program
{
    static void Main()
    {
        var root = new TrieNode();
        var roots = new List<TrieNode>();

        new [] { "ok", "test", "one", "try", "trying" }.
            ToList().
            ForEach(word =>
            {
                root.Add(word);
            });

        Console.WriteLine(root);

        new [] { 'a', 'b', 'c', 'o', 'k', 'd', 'e', 'f', 't', 'r', 'y', 'i', 'n', 'g' }.
            ToList().
            ForEach(letter =>
            {
                roots.Add(root);
                roots = roots.Select(x => x.GetNext(letter)).ToList();
                roots = roots.Where(x => x != null).ToList();
                var results = String.Join(
                                ", ",
                                roots.
                                    Where(x => x.IsWord).
                                    Select(y => y.Word));
                if (!String.IsNullOrWhiteSpace(results))
                {
                    Console.WriteLine(String.Format(
                            "{0} = \"{1}\"",
                            letter,
                            results));
                }
            });
    }
}

