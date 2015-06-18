using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
        dictionary[1] = new List<int> {2, 1};
        dictionary[2] = new List<int> {2, 3};
        dictionary[3] = new List<int> {3, 4};
        dictionary[4] = new List<int> {4, 1};
        Console.WriteLine(String.Join(" ",dictionary.Select(x => String.Format("{0}-[{1}] ", x.Key, String.Join(",", x.Value)))));

        dictionary = dictionary.Aggregate(new Dictionary<int, List<int>>(), (a, b) => {
                                              b.Value.ForEach(x => {
                                                    if (!a.ContainsKey(x)) {
                                                        a[x] = new List<int>();
                                                    }

                                                    a[x].Add(b.Key);
                                              });

                                              return a;
                                          });

        Console.WriteLine(String.Join(" ",dictionary.Select(x => String.Format("{0}-[{1}] ", x.Key, String.Join(",", x.Value)))));
    }
}
