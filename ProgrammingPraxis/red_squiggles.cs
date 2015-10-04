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
        bool IsWord = false;
    }
}

class Program
{
    static void Main()
    {
        Trie trie = new Trie();
        using (StreamReader reader = new StreamReader("/usr/share/dict/words"))
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
