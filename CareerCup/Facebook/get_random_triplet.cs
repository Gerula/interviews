// http://careercup.com/question?id=5678056593162240
//
// Given a function GetRandomTriplet
//
// which returns a random triplet of letters from a string.
//
// Given this and the length of the string, you need to guess the string.
//
// The triplet preserves the order of the letters in the word.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static Random random = new Random();

    static Tuple<char, char, char> Random(this String s)
    {
        var first = random.Next(0, s.Length - 2);
        var second = random.Next(first + 1, s.Length - 1);
        var third = random.Next(second + 1, s.Length);

        return Tuple.Create(
                s[first],
                s[second],
                s[third]);
    }

    static String GuessWord(String s)
    {
        var letters = new HashSet<char>();
        var sources = new HashSet<char>();
        var adj = new Dictionary<char, HashSet<char>>();
        while (letters.Count != s.Length)
        {
            var triple = s.Random();
            letters.Add(triple.Item1);
            letters.Add(triple.Item2);
            letters.Add(triple.Item3);
            adj.SafeAdd(triple.Item1, triple.Item2);
            adj.SafeAdd(triple.Item1, triple.Item3);
            adj.SafeAdd(triple.Item2, triple.Item3);
            sources.Add(triple.Item2);
            sources.Add(triple.Item3);
        }

        var result = new StringBuilder();
        var stack = new Stack<char>();
        var visited = new BitArray(255, false);
        
        letters
        .Except(sources)
        .First()
        .TopologicalSort(visited, stack, adj);
        
        while (stack.Count > 0)
        {
            result.Append(stack.Pop());
        }

        return result.ToString();
    }

    static void TopologicalSort(
            this char node,
            BitArray visited,
            Stack<char> stack,
            Dictionary<char, HashSet<char>> adj)
    {
        visited[node] = true;
        var neighbors = adj.ContainsKey(node) ? adj[node] : new HashSet<char>();
        foreach (var c in neighbors)
        {
            if (!visited[c])
            {
                c.TopologicalSort(visited, stack, adj);
            }
        }

        stack.Push(node);
    }

    static void SafeAdd(this Dictionary<char, HashSet<char>> dictionary, char key, char value)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = new HashSet<char>();
        }

        dictionary[key].Add(value);
    }

    static void Main()
    {
        foreach (var s in new [] {
                            "UNCOPYRIGHTABLE",
                            "SUBDERMATOGLYPHIC"
                          })
        {
            Console.WriteLine(GuessWord(s));
        }
    }
}
