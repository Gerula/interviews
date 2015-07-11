using System;

class Program {
    static void Main() {
        String s = "mumumumu";
        String t = "giugiugiugiu";
        String w = s;
        String n = "mumumumu";
        Console.WriteLine("{0}", Object.ReferenceEquals(s, n)); // Literals are interned automagically
        Console.WriteLine("{0} {1} {2}", s, s.GetHashCode(), String.IsInterned(s)); 
        Console.WriteLine("{0} {1} {2}", t, t.GetHashCode(), String.IsInterned(t));
        Console.WriteLine("{0} {1} {2}", w, w.GetHashCode(), String.IsInterned(w));
        Console.WriteLine("{0} {1} {2}", n, n.GetHashCode(), String.IsInterned(n));
    }
}
