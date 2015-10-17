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

    public uint Length { 
        get
        {
            uint i = 0;
            for (Node current = this; current != null; current = current.Next, i++) { }
            return i;
        }
    }

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

    public Node Tree()
    {
        Node thisNode = this;
        return Tree(0, (int)Length - 1, ref thisNode);
    }

    private static Node Tree(int low, int high, ref Node list)
    {
        if (low > high)
        {
            return null;
        }

        int mid = low + (high - low) / 2;
        Node node = new Node();
        node.Previous = Tree(low, mid - 1, ref list);

        node.Value = list.Value;
        list = list.Next;

        node.Next = Tree(mid + 1, high, ref list);
        return node;
    }

    private static void Levels(
            Node current, 
            int currentLevel, 
            Dictionary<int, List<int>> levels)
    {
        if (!levels.ContainsKey(currentLevel))
        {
            levels[currentLevel] = new List<int>();
        }

        levels[currentLevel].Add(current.Value);

        if (current.Previous != null)
        {
            Levels(current.Previous, currentLevel + 1, levels);
        }

        if (current.Next != null)
        {
            Levels(current.Next, currentLevel + 1, levels);
        }
    }

    public String Levels()
    {
        var levels = new Dictionary<int, List<int>>();
        Levels(this, 0, levels);
        return String.Join(
                Environment.NewLine,
                levels.Select(x => String.Join(", ", x.Value)));
                
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
        Console.WriteLine(root.Length);
        Node tree = root.Tree();
        Console.WriteLine(root.Tree());
        Console.WriteLine(tree.Levels());
        tree = Node.Inplace(root);
        Console.WriteLine(root.Tree());
        Console.WriteLine(tree.Levels());
    }
}
