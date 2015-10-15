// Given an array of words, find all shortest unique prefixes to represent each word in the given array. Assume that no word is prefix of another. 
//

using System;
using System.Collections.Generic;
using System.Linq;

class WordProcessor
{
    private class Node 
    {
        public readonly Dictionary<char, Node> Next = new Dictionary<char, Node>();
        public int Stamp = 0;
    }

    private Node Root;

    public WordProcessor()
    {
        Root = new Node();    
    }

    public void Add(String word)
    {
        var current = Root;
        foreach (char c in word)
        {
            if (!current.Next.ContainsKey(c)) 
            {
                current.Next[c] = new Node();
            }

            current.Stamp++;
            current = current.Next[c];
        }
    }

    public String Prefix(String word)
    {
        var count = 0;
        var idx = 0;
        var current = Root;
        while (current.Stamp != 1 && idx < word.Length)
        {
            count++;
            current = current.Next[word[idx++]];
        }

        return word.Substring(0, count);
    }
}

class Program
{
    static void Main()
    {
        var processor = new WordProcessor();
        var words = new List<String> {"zebra", "dog", "duck", "dove"};
        words.ForEach(processor.Add);
        Console.WriteLine(String.Join(
                                    Environment.NewLine,
                                    words.Select(x => String.Format("{0} = {1}", x, processor.Prefix(x)))));
    }
}
