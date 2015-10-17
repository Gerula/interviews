// http://careercup.com/question?id=5759495194017792
//
// Given a sorted double linked list, transform it into a balanced binary search tree
//

using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public int Value { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }

    public override String ToString()
    {
        return String.Format("{0} {1}{2}",
                             Previous == null? String.Empty : Previous.ToString(),
                             Value,
                             Next == null? String.Empty : Next.ToString());
    }

    public String ListToString()
    {
        return String.Format("{0} {1}",
                             Value,
                             Next == null? String.Empty : Next.ListToString());
    }
}

class Program 
{
    static void Main()
    {
        Node moq = new Node { Value = -1 };
        Node current = moq;
        Enumerable.
            Range(1, 100).
            ToList().ForEach(x => {
                        current.Next = new Node 
                                        { 
                                            Value = x, 
                                            Next = null, 
                                            Previous = current 
                                        };

                        current = current.Next;
                    });

        Node root = moq.Next;
        root.Previous = null;
        Console.WriteLine(root.ListToString());
    }
}
