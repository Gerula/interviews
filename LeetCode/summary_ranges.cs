using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int[] a = new int[] {0, 1, 2, 4, 5, 7};
        int[] set = Enumerable.Repeat(-1, a.Max() + 1).ToArray(); 
        Console.WriteLine(String.Join(",",
                          a.Aggregate(new Dictionary<int, int>(), (agg, b) => {
                               if (b >= 1 && set[b - 1] != -1) {
                                   agg[set[b - 1]] = b;
                                   set[b] = set[b - 1];                
                               } else {
                                   agg[b] = b;
                                   set[b] = b;
                               }

                               return agg;
                          }).Select(x => String.Format("[{0} => {1}]", x.Key, x.Value))));
    }
}
