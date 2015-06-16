using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program {

    private static void PowerSet(List<String> list, int count, List<String> result) {
        Console.WriteLine(String.Join(",", result));

        for (int i = count; i < list.Count(); i++) {
            result.Add(list[i]);
            PowerSet(list, i + 1, result);
            result.RemoveAt(result.Count() - 1);
        }
    }

    public static void Main(string[] args) {
        List<String> set = new List<String> {"Red", "White", "Blue"};
        List<String> result = new List<String>();
        
        for (int i = 0; i < Math.Pow(2, set.Count()); i++) {
            result.Clear();
            for (int j = 0; j < set.Count(); j++) {
                if ((i & (1 << j)) != 0) {
                    result.Add(set[j]);
                }
            }

            Console.WriteLine(String.Join(",", result));
        }

        Console.WriteLine();
        PowerSet(set, 0, new List<String>());
    }
}
