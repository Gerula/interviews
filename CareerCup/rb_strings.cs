using System;
using System.Collections.Generic;
using System.Linq;

static class Program {
    static int MaxLength(this List<String> input) {
        var aggregate = input.Aggregate(new Dictionary<String, List<int>>(), (agg, x) => {
                            String id = String.Format("{0}{1}", x[0], x[x.Length - 1]);
                            if (id == "RR" || id == "BR" || id == "RB" || id == "BB") {
                                if (!agg.ContainsKey(id)) {
                                    agg[id] = new List<int>();
                                } 

                                agg[id].Add(x.Length);
                            }

                            return agg;
                        });

        var br = aggregate.ContainsKey("BR") ? aggregate["BR"] : new List<int>();
        var rb = aggregate.ContainsKey("RB") ? aggregate["RB"] : new List<int>();
        var rr = aggregate.ContainsKey("RR") ? aggregate["RR"] : new List<int>();
        var bb = aggregate.ContainsKey("BB") ? aggregate["BB"] : new List<int>();
        br = br.OrderBy(x => x).ToList();
        rb = rb.OrderBy(x => x).ToList();
        int minLength = br.Count < rb.Count ? br.Count : rb.Count;
        int result = rr.Sum() + bb.Sum();
        for (int i = 0; i < minLength; i++) {
            result += br[i] + rb[i];
        }

        for (int i = minLength; i < br.Count || i < rb.Count; i++) {
            if (i < br.Count) {
                result += br[i];
            } else {
                result += rb[i];
            }
        }

        return result;
    }

    static void Main() {
        List<String> strings = new List<String>() {"RBR", "BBR", "RRR"};
        Console.WriteLine(strings.MaxLength());
    }
}
