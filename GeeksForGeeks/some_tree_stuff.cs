using System;
using System.Collections.Generic;
using System.Linq;

class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
    public TreeNode Parent { get; set; }
    
    public IEnumerable<TreeNode> Parents()
    {
        yield return this;

        if (Parent == null)
        {
            yield break;
        }

        foreach (var parent in Parent.Parents())
        {
            yield return parent;
        }
    }
}

class Solution
{
    //  http://www.geeksforgeeks.org/diagonal-traversal-of-binary-tree/
    static IList<IList<int>> Diagonal(TreeNode root)
    {
        var result = new List<IList<int>>();
        Diagonal(root, 0, result);
        return result;
    }

    static void Diagonal(TreeNode root, int level, IList<IList<int>> result)
    {
        if (root == null)
        {
            return;
        }

        if (result.Count == level)
        {
            result.Add(new List<int>());
        }

        result[level].Add(root.Value);
        Diagonal(root.Left, level + 1, result);
        Diagonal(root.Right, level, result);
    }

    static IEnumerable<IList<int>> Paths(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Any())
        {
            var current = stack.Pop();
            if (current.Left == null && current.Right == null)
            {
                yield return current.Parents().Select(x => x.Value).ToList();
            }
            
            if (current.Left != null)
            {
                current.Left.Parent = current;
                stack.Push(current.Left);
            }

            if (current.Right != null)
            {
                current.Right.Parent = current;
                stack.Push(current.Right);
            }
        }
    }

    static void Main()
    {
        var tree = new TreeNode {
            Value = 8,
            Left = new TreeNode {
                Value = 3,
                Left = new TreeNode {
                    Value = 1
                },
                Right = new TreeNode {
                    Value = 6,
                    Left = new TreeNode {
                        Value = 4
                    },
                    Right = new TreeNode {
                        Value = 7
                    }
                }
            },
            Right = new TreeNode {
                Value = 10,
                Right = new TreeNode {
                    Value = 14
                },
                Left = new TreeNode {
                    Value = 13
                }
            }
        };

        Console.WriteLine(String.Join(Environment.NewLine, Diagonal(tree).Select(x => String.Join(", ", x))));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, Paths(tree).Select(x => String.Join(", ", x))));
    }
}
