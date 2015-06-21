using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program {
    static void Main() {
        int n = 5;
        StringBuilder spaces = new StringBuilder();
        for (int i = 0; i < n; i++) {
            spaces.Append("  ");
        }

        Enumerable.Range(1, 5).Aggregate(new List<int>() { 1 }, (agg, current) => {
                                            Console.WriteLine("{0}{1}", spaces, String.Join(" , ", agg));
                                            List<int> newList = new List<int>() { 1 };
                                            if (agg.Count > 1) {
                                                newList.AddRange(agg.Select((x, i) => { if (i < agg.Count - 1) {
                                                                                    return x + agg[i + 1];
                                                                                 } else {
                                                                                    return 0;
                                                                                 }
                                                                                 }).ToList());
                                                newList.RemoveAt(newList.Count - 1);
                                            }

                                            newList.Add(1);
                                            spaces.Length -= 2;
                                            return newList;
                                        });
    }
}
