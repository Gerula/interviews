using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        List<Tuple<int, int>> intervals = new List<Tuple<int, int>> {
            new Tuple<int, int> (2, 6),
            new Tuple<int, int> (1, 3),
            new Tuple<int, int> (8, 10),
            new Tuple<int, int> (15, 18)
        };

        Console.WriteLine(String.Join(",", intervals.Select(x => String.Format("[{0}, {1}]", x.Item1, x.Item2))));
        intervals = intervals.OrderBy(x => x.Item1).ToList();

        int i = 0;
        while (i < intervals.Count - 1) {
            if (intervals[i].Item2 > intervals[i + 1].Item1) {
                intervals[i] = new Tuple<int, int>(intervals[i].Item1, intervals[i + 1].Item2);
                intervals.RemoveAt(i + 1);
            } else {
                i++;
            }
        }

        Console.WriteLine(String.Join(",", intervals.Select(x => String.Format("[{0}, {1}]", x.Item1, x.Item2))));
    }
}
