//  https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
//
//  What if the given tree could be any binary tree? Would your previous solution still work?
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Node
{
    public int Val;
    public Node Left;
    public Node Right;
    public Node Next;

    public static Node Build(int low, int high)
    {
        if (low > high)
        {
            return null;
        }

        var mid = low + (high - low) / 2;
        return new Node {
            Val = mid,
            Left = Build(low, mid - 1),
            Right = Build(mid + 1, high)
        };
    }

    public void Connect()
    {
        var dummy = new Node { Val = 0 };
        var root = this;

        while (root != null)
        {
            Node currentChild = dummy;
            while (root != null)
            {
                if (root.Left != null)
                {
                    currentChild.Next = root.Left;
                    currentChild = currentChild.Next;
                }

                if (root.Right != null)
                {
                    currentChild.Next = root.Right;
                    currentChild = currentChild.Next;
                }

                root = root.Next;
            }

            root = dummy.Next;
            dummy.Next = null;
        }
    }

    public override String ToString()
    {
        var q = new Queue<Node>();
        var curLevel = 1;
        var nextLevel = 0;
        q.Enqueue(this);
        var result = new StringBuilder();

        while (q.Count > 0)
        {
            curLevel--;
            var cur = q.Dequeue();
            result.Append(String.Format("{0} - next {1} ", cur.Val, cur.Next == null ? "N" : cur.Next.Val.ToString()));
            if (cur.Left != null)
            {
                nextLevel++;
                q.Enqueue(cur.Left);
            }

            if (cur.Right != null)
            {
                nextLevel++;
                q.Enqueue(cur.Right);
            }

            if (curLevel == 0)
            {
                curLevel = nextLevel;
                nextLevel = 0;
                result.Append(Environment.NewLine);
            }
        }

        return result.ToString();
    }
}

class Program
{
    static void Main()
    {
        var root = Node.Build(0, 25);
        root.Left.Right = null;
        root.Right.Left = null;
        Console.WriteLine(root);
        root.Connect();
        Console.WriteLine(root);
    }
}
