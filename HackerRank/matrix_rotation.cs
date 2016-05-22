//  https://www.hackerrank.com/challenges/matrix-rotation-algo
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Process(int[][] a, int k) {
        var layers = Math.Min(a.Length, a[0].Length) / 2;
        for (var layer = 0; layer < layers; layer++) {
            var x = GetLayer(a, layer);
            Rotate(x, k);
            SetLayer(a, x, layer);
        }
        
        for (var i = 0; i < a.Length; i++) {
            Console.WriteLine(String.Join(" ", a[i]));
        }
    }
    
    static List<int> GetLayer(int[][] a, int k) {
        var layer = new List<int>();
        var n = a.Length;
        var m = a[0].Length;
        for (var i = k; i < m - k; i++) {
            layer.Add(a[k][i]);
        }
        
        for (var i = k + 1; i < n - k; i++) {
            layer.Add(a[i][m - k - 1]);
        }
        
        for (var i = m - k - 2; i >= k; i--) {
            layer.Add(a[n - k - 1][i]);
        }
        
        for (var i = n - k - 2; i > k; i--) {
            layer.Add(a[i][k]);
        }
        
        return layer;
    }
    
    static void SetLayer(int[][] a, List<int> layer, int k) {
        var n = a.Length;
        var m = a[0].Length;
        var idx = 0;
        for (var i = k; i < m - k; i++) {
            a[k][i] = layer[idx++];
        }
        
        for (var i = k + 1; i < n - k; i++) {
            a[i][m - k - 1] = layer[idx++];
        }
        
        for (var i = m - k - 2; i >= k; i--) {
            a[n - k - 1][i] = layer[idx++];
        }
        
        for (var i = n - k - 2; i > k; i--) {
            a[i][k] = layer[idx++];
        }
    }
    
    static void Rotate(List<int> a, int k) {
        k = k % a.Count;
        if (k == 0) {
            return;
        }
        
        Reverse(a, 0, k - 1);
        Reverse(a, k, a.Count - 1);
        Reverse(a, 0, a.Count - 1);
    }
    
    static void Reverse(List<int> a, int start, int end) {
        while (start < end) {
            var c = a[start];
            a[start++] = a[end];
            a[end--] = c;
        }
    }
        
    static void Main(String[] args) {
        var line = ReadLine();
        var rows = line[0];
        var k = line[2];
        var a = new int[rows][];
        for (var i = 0; i < rows; i++) {
            a[i] = ReadLine();
        }
        
        Process(a, k);
    }
    
    static int[] ReadLine() {
        return Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
    }
}
