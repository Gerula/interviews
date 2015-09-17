using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        List<int> input = new List<int> {1, 2, 3, 10, 25, 26, 30, 31, 32, 33};
        HashSet<int> accounting = new HashSet<int>(input);
        var intervals = new [] {new {Low = 0, High = 0}}.ToList();
        intervals.RemoveAt(0);

        foreach (var number in input) {
            if (!accounting.Contains(number)) {
                continue;
            }

            int high = number;
            int low = number;
            while (accounting.Contains(high)) {
                accounting.Remove(high++);
            }
            high--;

            while (accounting.Contains(--low)) {
                accounting.Remove(low + 1);
            }
            low++;

            intervals.Add(new { Low = low, High = high});
        }

        Console.WriteLine(String.Join(
                          ", ",
                          intervals.Select(x => x.High == x.Low ? x.High.ToString() : String.Format("{0} - {1}", x.Low, x.High))));
    }
}
