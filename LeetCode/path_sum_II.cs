using System;
using System.Collections.Generic;
using System.Linq;

class Node {
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public override String ToString() {
        return String.Format("{0} {1} {2}",
                             (Left == null) ? String.Empty : Left.ToString(),
                             Data,
                             (Right == null) ? String.Empty : Right.ToString());
    }

    public List<List<int>> GetSums(int sum, List<int> path) {
        if (sum - Data == 0)
        {
            path.Add(Data);
            if (Left == null && Right == null) {
                List<List<int>> result = new List<List<int>>();
                result.Add(new List<int>(path));
                return result;
            } else {
                return null;
            }
        }

        List<List<int>> rootResult = new List<List<int>>();
        if (Left != null) {
            path.Add(Data);
            rootResult.AddRange(Left.GetSums(sum - Data, path));
            path.RemoveAt(path.Count - 1);
        }

        if (Right != null) {
            path.Add(Data);
            rootResult.AddRange(Right.GetSums(sum - Data, path));
            path.RemoveAt(path.Count - 1);
        }

        return rootResult.Distinct().ToList();
    }
}

class Program {
    static void Main() {
        Node root = new Node {
                        Data = 5,
                        Left = new Node {
                                   Data = 4,
                                   Left = new Node {
                                              Data = 11,
                                              Left = new Node {
                                                         Data = 7,
                                                         Left = null,
                                                         Right = null},
                                              Right = new Node {
                                                          Data = 2,
                                                          Left = null,
                                                          Right = null}},
                                   Right = null},
                        Right = new Node {
                                    Data = 8,
                                    Left = new Node {
                                               Data = 13,
                                               Left = null,
                                               Right = null},
                                    Right = new Node {
                                                Data = 4,
                                                Left = new Node {
                                                           Data = 5,
                                                           Left = null,
                                                           Right = null},
                                                Right = new Node {
                                                            Data = 1,
                                                            Left = null,
                                                            Right = null}}}};

        Console.WriteLine(root);
        foreach (var sum in root.GetSums(22, new List<int>())) {
            Console.WriteLine(String.Join(", ", sum));
        }
    }
}
