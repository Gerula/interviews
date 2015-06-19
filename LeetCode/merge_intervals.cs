using System;
using System.Collections.Generic;
using System.Linq;

class Program {

    static List<Tuple<int, int>> merge(List<Tuple<int, int>> intervals) {
        int[] serialized = Enumerable.Repeat(0, 100).ToArray();
        intervals.ForEach(x => { 
                    for (int i = x.Item1; i<= x.Item2; i++) {
                        serialized[i] = 1;
                    }
                });

        intervals.Clear();
        bool found = false;
        int left = 0;
        int right = 0;
        for (int i = 0; i < 100; i++) {
            if ((serialized[i] == 1) && !found) {
                found = true;
                left = i;
                continue;
            }

            if (found && (serialized[i] == 0 || i == 100 - 1)) {
                found = false;
                right = i - 1;
                intervals.Add(new Tuple<int, int>(left, right));
            }
        }

        return intervals;
    }

    static void Main() {
        List<Tuple<int, int>> intervals = new List<Tuple<int, int>> {
            new Tuple<int, int> (2, 6),
            new Tuple<int, int> (1, 3),
            new Tuple<int, int> (8, 10),
            new Tuple<int, int> (15, 18)
        };

        Console.WriteLine(String.Join(",", intervals.Select(x => String.Format("[{0}, {1}]", x.Item1, x.Item2))));
        List<Tuple<int, int>> intervals2 = new List<Tuple<int, int>>();
        intervals2.AddRange(intervals);
        Console.WriteLine("Second method : {0}", String.Join(",", merge(intervals2).Select(x => String.Format("[{0}, {1}]", x.Item1, x.Item2))));
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
