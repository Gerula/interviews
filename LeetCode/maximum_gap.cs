using System;
using System.Linq;

class Program {
    static int MaxGap(int[] a) {
        int min = a.Min();
        int max = a.Max();
        float interval = (float) a.Length / (max - min);
        Tuple<int, int>[] buckets = new Tuple<int, int>[a.Length + 1];

        foreach (int val in a) {
            int bucket = (int)((val - min) * interval);
            if (buckets[bucket] == null) {
                buckets[bucket] = new Tuple<int, int>(val, val);
            } else {
                Tuple<int, int> current = buckets[bucket];
                buckets[bucket] = new Tuple<int, int>(Math.Min(current.Item1, val), Math.Max(current.Item2, val));
            }
        }

        int maxDifference = int.MinValue;
        int prev = buckets[0].Item2;
        for (int i = 1; i < buckets.Length; i++) { 
            if (buckets[i] != null) {
                maxDifference = Math.Max(maxDifference, buckets[i].Item1 - prev);
                prev = buckets[i].Item2;
            }
        }

        return maxDifference;
    }

    static void Main() {
        int[] a = new int[] {5, 2, 10, 15, 8, 7};
        Console.WriteLine(MaxGap(a));
        a = a.OrderBy(x => x).ToArray();
        Console.WriteLine(a.Select((x, i) => {
                                              if (i > 0) {
                                                 return a[i] - a[i - 1];
                                              } else {
                                                 return 0;
                                              }
                                             }).Max());
    }
}
