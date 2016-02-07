// Print a trie

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Node 
{
    private Dictionary<char, Node> Next = new Dictionary<char, Node>();
    private bool IsWord;

    public static Node Read(List<String> items)
    {
        return items
               .Aggregate(
                       new Node(),
                       (acc, x) => {
                            var root = acc;
                            for (var i = 0 ; i < x.Length; i++)
                            {
                                if (!root.Next.ContainsKey(x[i]))
                                {
                                    root.Next[x[i]] = new Node {
                                        IsWord = i == x.Length - 1
                                    };
                                }

                                root = root.Next[x[i]];
                            }

                            return acc;
                       });
    }

    public static List<String> Write(Node node)
    {
        return node.Next.Keys.Count == 0 ?
                    new [] { String.Empty }.ToList() :
                    node.Next.Keys.SelectMany(x => Write(node.Next[x]).Select(y => String.Format("{0}{1}", x, y)).ToList())
                    .OrderBy(x => x)
                    .ToList();
    }
}

class Solution
{
    static IEnumerable<String> GetWords(int n)
    {
        var r = new Random();
        var lines = File.ReadAllLines("/usr/share/dict/words");
        return Enumerable
               .Range(0, n)
               .Select(x => lines[r.Next(lines.Length)]);
    }

    static void Main()
    {
        var words = GetWords(100).OrderBy(x => x).ToList();
        Console.WriteLine(String.Join(", ", words));
        Console.WriteLine(String.Join(", ", Node.Write(Node.Read(words))));
        if (!words.SequenceEqual(Node.Write(Node.Read(words))))
        {
            Console.WriteLine("HAHAHA IDOIT!!!");
        }
    }
}
