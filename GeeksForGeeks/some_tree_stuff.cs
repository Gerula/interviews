using System;
using System.Collections.Generic;
using System.Linq;

class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
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
    }
}
