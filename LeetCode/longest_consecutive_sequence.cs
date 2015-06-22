using System;
using System.Collections.Generic;

class Program {
    static int LCS(int[] nums) {
        HashSet<int> parsed = new HashSet<int>();
        Dictionary<int, int> intervals = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            int num = nums[i];
            if (parsed.Contains(num)) {
                continue;
            }

            parsed.Add(num);
            int low = num;
            int high = num;
            if (intervals.ContainsKey(num - 1)) {
                low = intervals[num - 1];
                intervals.Remove(num - 1);
            }
            if (intervals.ContainsKey(num + 1)) {
                high = intervals[num + 1];
                intervals.Remove(num + 1);
            }

            intervals[low] = high;
            intervals[high] = low;
        }

        int lo = 0; int hi = 0;
        foreach (var interval in intervals) {
            if (hi - lo < interval.Key - interval.Value) {
                lo = interval.Value;
                hi = interval.Key;
            }
        }
        
        for (int i = 0; i < hi - lo + 1; i++) {
            Console.Write("{0} ", i + lo);
        }
        
        Console.WriteLine();
        return hi - lo + 1;
    }

    static void Main() {
        LCS(new int[] {100, 4, 200, 1, 3, 2});
    }
}
