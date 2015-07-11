using System;
using System.Collections.Generic;
using System.Linq;

static class Program {
    static String LongestPrefix(this List<String> words) {
        int minLength = words.Select(x => x.Length).Min();
        int i = 0;
        while (i < minLength) {
            var list = words.Select(x => x[i]);
            var pairs = list.Zip(list.Skip(1), Tuple.Create);
            if (!pairs.Aggregate(true, (a, b) => {
                        return a && (b.Item1 == b.Item2);  
                      })) {
                break;
            }
            
            i++;
        }

        return words.First().Substring(0, i);
    }

    static void Main() {
        Console.WriteLine(new List<String> {"banana", "bananarama", "bananar"}.LongestPrefix());        
    }
}
