using System;
using System.Collections.Generic;

class Program
{
    class ListNode
    {
        public int Val { get; set; }
        public ListNode Left { get; set; }
        public ListNode Right { get; set; }

        public ListNode First() 
        {
            var it = this;
            while (it.Left != null)
            {
                it = it.Left;
            }

            return it;
        }

        public IEnumerable<int> Values()
        {
            var it = this;
            while (it != null)
            {
                yield return it.Val;
                it = it.Right;
            }
        }
    }

    class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    static void VerticalSum(TreeNode t, ListNode l)
    {
        l.Val += t.Val;
        if (t.Left != null)
        {
            l.Left = l.Left == null ? new ListNode () : l.Left;
            l.Left.Right = l;
            VerticalSum(t.Left, l.Left);
        }

        if (t.Right != null)
        {
            l.Right = l.Right == null ? new ListNode() : l.Right;
            l.Right.Left = l;
            VerticalSum(t.Right, l.Right);
        }
    }

    static void Vertical(TreeNode t)
    {
        var l = new ListNode();
        VerticalSum(t, l);
        Console.WriteLine(String.Join(", ", l.First().Values()));
    }

    static void Main()
    {
        Vertical(new TreeNode() {
            Val = 1,
            Left = new TreeNode() {
                Val = 2,
                Left = new TreeNode() {
                    Val = 4
                },
                Right = new TreeNode() {
                    Val = 5
                }
            },
            Right = new TreeNode() {
                Val = 3,
                Left = new TreeNode() {
                    Val = 6
                },
                Right = new TreeNode() {
                    Val = 7
                }
            }
        });
    }
}
