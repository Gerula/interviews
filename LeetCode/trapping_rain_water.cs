using System;

class Program {
    static void Main() {
        int[] values = new int[] {0,1,0,2,1,0,1,3,2,1,2,1};
        int n = values.Length;
        int[] max_l = new int[n];
        int[] max_r = new int[n];
        max_l[0] = 0;
        for (int i = 1; i < n; i++) {
            max_l[i] = Math.Max(max_l[i - 1], values[i - 1]);
        }

        max_r[n - 1] = 0;
        for (int i = n - 2; i >= 0; i--) {
            max_r[i] = Math.Max(max_r[i + 1], values[i + 1]);
        }

        int water = 0;
        for (int i = 0; i < n; i++) {
            water += Math.Max(Math.Min(max_l[i], max_r[i]) - values[i], 0);
        }

        Console.WriteLine(water);
    }
}
