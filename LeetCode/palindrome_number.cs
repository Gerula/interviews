using System;
using System.Linq;

static class Program {
    static bool Palindrome(this int n) {
        return n.ToString().ToCharArray().SequenceEqual(n.ToString().Reverse());
    }

    static void Main() {
        Console.WriteLine(String.Join(", ", Enumerable.Range(1000, 1000).Where(x => x.Palindrome())));
    }
}
