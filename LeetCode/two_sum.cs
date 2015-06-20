using System;
using System.Collections.Generic;

class Program {
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
        int[] input = new int[] {2, 2, 7, 11, 15};
        Console.WriteLine(TwoSum(input, 4));
    }
}
