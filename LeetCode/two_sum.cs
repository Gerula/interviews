using System;
using System.Collections.Generic;
using System.Linq;

class Program {

    static Tuple<int, int> TwoSum2(int[] input, int sum) {
        var hash = input.ToList().ToDictionary(x => x, x => Array.IndexOf(input, x));
        return hash.Where(x => hash.ContainsKey(sum - x.Key)).Select(x => new Tuple<int, int>(x.Value + 1, hash[sum - x.Key] + 1)).First();
    }

    static Tuple<int, int> TwoSum(int[] input, int sum) {
        Dictionary<int, int> indexes = new Dictionary<int, int>();
        for (int i = 0; i < input.Length; i++) {
            if (indexes.ContainsKey(sum - input[i])) {
                return new Tuple<int, int>(indexes[sum - input[i]] + 1, i + 1);
            }

            indexes[input[i]] = i;
        }
        
        return null;
    }

    static void Main() {
        int[] input = new int[] {2, 7, 11, 15};
        Console.WriteLine(TwoSum(input, 9));
        Console.WriteLine(TwoSum2(input, 9));
    }
}
