// https://www.reddit.com/r/dailyprogrammer/comments/3n55f3/20150930_challenge_234_intermediate_red_squiggles/
//
// Your challenge today is to implement a real time spell checker and indicate where you would throw the red squiggle. For your dictionary use /usr/share/dict/words 
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
        return Enumerate(s).Count();
    }

    public List<String> GetSuggestions(String s)
    {
        StringBuilder sb = new StringBuilder();
        var triePath = Enumerate(s);
        sb.Append(s.Substring(0, triePath.Count()));
        List<String> result = new List<String>();
        GenerateSuggestions(triePath.Last(), sb, result);
        return result;
    }

    public override String ToString()
    {
        return Root.ToString();
    }

    private void GenerateSuggestions(Node current, StringBuilder sb, List<string> result)
    {
        if (current.IsWord)
        {
            result.Add(sb.ToString());
        }

        foreach (var c in current.Next.Keys)
        {
            sb.Append(c);
            GenerateSuggestions(current.Next[c], sb, result);
            sb.Length--;
        }
    }

    private IEnumerable<Node> Enumerate(String s)
    {
        Node current = Root;
        foreach (char c in s)
        {
            if (current.Next.ContainsKey(c))
            {
                yield return current;
                current = current.Next[c];
            }
        }
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
                Console.WriteLine("[Suggestions: {0}]", String.Join(", ", trie.GetSuggestions(line)));
            }
            else
            {
                Console.WriteLine(line);
            }
        }
    }
}
