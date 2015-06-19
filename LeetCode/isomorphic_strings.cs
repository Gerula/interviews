using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static bool Isomorphic(String s, String t) {
        return s.Select(x => s.IndexOf(x)).SequenceEqual(t.Select(x => t.IndexOf(x)));
    }

    static void Main() {
        var input = new List<Tuple<String, String>>() {
            new Tuple<String, String>("egg", "add"),
            new Tuple<String, String>("foo", "bar"),
            new Tuple<String, String>("paper", "title")
        };

        Console.WriteLine(String.Join(",", input.Select(x => String.Format("{0} - {1}", x, Isomorphic(x.Item1, x.Item2)))));
    }
}
