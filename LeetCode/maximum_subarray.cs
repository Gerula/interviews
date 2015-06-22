using System;
using System.Collections.Generic;

class Program {
    static int Sum(List<int> a, int left, int mid, int right) {
        int max_left = int.MinValue;
        int max_right = int.MinValue;
        int sum = 0;
        for (int i = left; i <= mid; i++) {
            sum += a[i];
            max_left = Math.Max(max_left, sum);
        }

        sum = 0;
        for (int i = mid + 1; i <= right; i++) {
            sum += a[i];
            max_right = Math.Max(max_right, sum);
        }

        return max_left + max_right;
    }
    
    static int MaxSum(List<int> a, int left, int right) {
        if (left == right) {
            return a[left];
        }

        int mid = left + (right - left) / 2;
        return Math.Max(
                        Math.Max(
                                 MaxSum(a, left, mid), 
                                 MaxSum(a, mid + 1, right)), 
                        
                        Sum(a, left, mid, right));
    }

    static void Main() {
        List<int> a = new List<int>();
        a.Add(-2); a.Add(1); a.Add(-3); a.Add(4); a.Add(-1); a.Add(2); a.Add(1); a.Add(-5); a.Add(4);
        int global_max = a[0];
        int local_max = a[0];

        for (int i = 1; i < a.Count; i++) {
            local_max = Math.Max(local_max + a[i], 0);
            global_max = Math.Max(local_max, global_max);
        }

        Console.WriteLine(global_max);
        Console.WriteLine(MaxSum(a, 0, a.Count - 1));
    }
}
