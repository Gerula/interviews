// https://www.reddit.com/r/dailyprogrammer/comments/3n55f3/20150930_challenge_234_intermediate_red_squiggles/
//
// Your challenge today is to implement a real time spell checker and indicate where you would throw the red squiggle. For your dictionary use /usr/share/dict/words 
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Trie
{
    private class Node
    {
        internal Dictionary<char, Node> Next = new Dictionary<char, Node>();
        internal bool IsWord = false;
        
        public override String ToString()
        {
            return String.Format("[Node.IsWord:{0} {1}]",
                                 IsWord,
                                 String.Join(", ", Next.Select(x => 
                                                               String.Format("{0} => {1}", x.Key, x.Value.ToString()))));
        }
    }
    
    private readonly Node Root = new Node();

    public void Add(String s)
    {
        Node current = Root;
        for (int i = 0; i < s.Length; i++)
        {
            Node next;
            if (!current.Next.TryGetValue(s[i], out next))
            {
                next = new Node();
                current.Next[s[i]] = next;
            }
        
            next.IsWord = i == s.Length - 1;
            current = next;
        }
    }

    public int ContainsCount(String s)
    {
        Node current = Root;
        int result = 0;
        foreach (var c in s)
        {
            if (!current.Next.ContainsKey(c))
            {
                return result;
            }

            result++;
            current = current.Next[c];
        }

        return s.Length;
    }

    public override String ToString()
    {
        return Root.ToString();
    }
}

class Program
{
    static IEnumerable<String> ReadLinesFromFile(String pathToFile)
    {
        using (StreamReader reader = new StreamReader(pathToFile))
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    static void Main()
    {
        Trie trie = new Trie();
        foreach(var line in ReadLinesFromFile("/usr/share/dict/words"))
        {
            trie.Add(line);
        }

        foreach(var line in ReadLinesFromFile("red_squiggles.in"))
        {
            int position = trie.ContainsCount(line);
            if (position != line.Length)
            {
                Console.WriteLine(line.Insert(position - 1, "<"));
            }
            else
            {
                Console.WriteLine(line);
            }
        }
    }
}
