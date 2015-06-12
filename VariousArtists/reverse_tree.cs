using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program {

    public class TreeNode {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    public class Tree {
        public TreeNode Root { get; private set;}

        public Tree(int start, int end) 
        {
            Root = Construct(start, end);
        }

        private TreeNode Construct(int left, int right)
        {
            if (left > right) {
                return null;
            }

            int mid = left + (right - left) / 2;
            return new TreeNode {
                Value = mid,
                Left = Construct(left, mid - 1),
                Right = Construct(mid + 1, right)
            };
        }

        public override String ToString()
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            StringBuilder result = new StringBuilder();
            TreeNode current = Root;
            while (stack.Any() || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    result.Append(String.Format("{0} ", current.Value));
                    current = current.Right;
                }
            }

            return result.ToString();
        }
    }

    public static void Main(String[] args) {
        Tree tree = new Tree(0, 10);
        Console.WriteLine(tree);
    }
}
