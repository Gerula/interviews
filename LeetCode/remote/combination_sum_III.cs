using System;
using System.Collections.Generic;
using System.Linq;

// You are here!
// Your runtime beats -0.00% of csharp coders. <- Aahahahahahaha!!!
//
// https://leetcode.com/submissions/detail/38153904/
//
// 
// Submission Details
// 18 / 18 test cases passed.
//  Status: Accepted
//  Runtime: 460 ms
//      
//      Submitted: 0 minutes ago
//

class Program {
    public static IList<IList<int>> CombinationSum3(int k, int n) {
         IList<IList<int>> result = new List<IList<int>>();
         Combinations(0, k, 1, n, result, new List<int>());
         return result;
    }

    private static void Combinations(int sum, int k, int count, int n, IList<IList<int>> result, List<int> partial) {
        if (sum == n && partial.Count == k) {
            result.Add(new List<int>(partial));
            return;
        }

        for (int i = count; i <= 9; i++) {
            if (sum + i <= n && partial.Count < k) {
                partial.Add(i);
                Combinations(sum + i, k, i + 1, n, result, partial);
                partial.Remove(i);
            }
        }
    }

    public static void Main() {
        Console.WriteLine(String.Join("; ", CombinationSum3(3, 9).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join("; ", CombinationSum3(0, 9).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join("; ", CombinationSum3(0, 0).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join("; ", CombinationSum3(1, 1).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join("; ", CombinationSum3(3, 15).Select(x => String.Join(", ", x))));
    }
}
