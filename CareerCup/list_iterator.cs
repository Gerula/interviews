// http://careercup.com/question?id=5759529096577024
//
// Given a linked list consisting of String in each Node.
// Given just a pointer to the head Node find whether the
// resultant String formed by combining all the Nodes of
// the linked list is a palindrome or not in O(1) space and O(n) time.
//

using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public String Val { get; set; }
    public Node Next { get; set; }

    public IEnumerable<char> GetEnumerator()
    {
        foreach (var c in this.Val.ToList().Concat(Next == null ? new char[0] : Next.GetEnumerator()))
        {
            yield return c;
        }
    }

    public bool IsPalindrome()
    {
        return this.GetEnumerator().SequenceEqual(this.GetEnumerator().Reverse());
    }
}

static class Program
{
    static void Main()
    {
        Node head = null;
        new [] {
            "caba",
            "d",
            "efe",
            "cd",
            "aba"
        }
        .ToList()
        .ForEach(x => {
                    head = new Node { Val = x, Next = head };
                });

        Console.WriteLine("{0} = {1}", String.Join(", ", head.GetEnumerator()), head.IsPalindrome());
        head = new Node { Val = "x", Next = head };
        Console.WriteLine("{0} = {1}", String.Join(", ", head.GetEnumerator()), head.IsPalindrome());
    }
}
