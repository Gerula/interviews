using System;
using System.Collections.Generic;

class Program {
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
    }
}
