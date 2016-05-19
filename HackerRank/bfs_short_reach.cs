//  https://www.hackerrank.com/challenges/bfsshortreach
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static int[] Cost(Dictionary<int, HashSet<int>> a, int n, int start) {
        var cost = new Dictionary<int, int>();
        var queue = new Queue<int>();
        var hash = new HashSet<int>();
        queue.Enqueue(start);
        hash.Add(start);
        cost[start] = 0;
        while (queue.Count > 0) {
            var current = queue.Dequeue();
            if (!a.ContainsKey(current)) {
                continue;
            }
            
            foreach (var x in a[current].Where(x => !hash.Contains(x))) {
                hash.Add(x);
                cost[x] = 6 + cost[current];
                queue.Enqueue(x);
            }
        }
        
        return Enumerable
               .Range(1, n)
               .Where(x => x != start)
               .Select(x => cost.ContainsKey(x) ? cost[x] : -1)
               .ToArray();
    }

    static void Main(String[] args) {
        var testCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < testCount; i++) {
            var n = 0;
            var m = 0;
            ReadTwoInts(out n, out m);
            var a = new Dictionary<int, HashSet<int>>();
            for (var j = 0; j < m; j++) {
                var start = 0;
                var end = 0;
                ReadTwoInts(out start, out end);
                if (!a.ContainsKey(start)) {
                    a[start] = new HashSet<int>();
                }
                
                if (!a.ContainsKey(end)) {
                    a[end] = new HashSet<int>();
                }
                
                a[start].Add(end);
                a[end].Add(start);
            }
            
            var s = int.Parse(Console.ReadLine());
            Console.WriteLine(String.Join(" ", Cost(a, n, s)));
        }
    }
    
    static void ReadTwoInts(out int a, out int b) {
        var s = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        a = s[0];
        b = s[1];
    }
}
