//  https://www.hackerrank.com/challenges/similarpair
//  8 out of 10 passed. Very inefficient.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Node {
    public int Label { get; set; }
    public HashSet<Node> Children { get; set; }
    
    public override String ToString() {
        return String.Format("{0} [{1}]", Label, String.Join(", ", Children.Select(x => x.ToString())));
    }
}

class Solution {
    static Tuple<int, List<int>> SimilarPairs(Node root, int t) {
        var count = 0;
        var descendants = new List<int>();
        foreach (var x in root.Children.Select(y => SimilarPairs(y, t))) {
            count += x.Item1;
            foreach (var y in x.Item2) {
                descendants.Add(y);
                if (Math.Abs(root.Label - y) <= t) {
                    count++;
                }
            }
        }
        
        descendants.Add(root.Label);
        return Tuple.Create(count, descendants);
    }
    
    static void Main(String[] args) {
        var n = 0; var t = 0;
        ReadTwoInts(out n, out t);
        var nodes = Enumerable.Range(1, n).Aggregate(
                        new Dictionary<int, Node>(),
                        (acc, x) => {
                           acc[x] = new Node { Label = x, Children = new HashSet<Node>() };
                           return acc;
                        });

        var roots = new HashSet<int>(Enumerable.Range(1, n));
        for (var i = 0; i < n - 1; i++) {
            var parent = 0; var child = 0;
            ReadTwoInts(out parent, out child);
            nodes[parent].Children.Add(nodes[child]);
            roots.Remove(child);
        }
        
        Console.WriteLine(SimilarPairs(nodes[roots.First()], t).Item1);
    }
    
    static void ReadTwoInts(out int a, out int b) {
        var s = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        a = s[0];
        b = s[1];
    }
}
