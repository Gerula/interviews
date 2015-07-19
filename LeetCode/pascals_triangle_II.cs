// Pascal's Triangle II Total Accepted: 45748 Total Submissions: 155257
//
// Given an index k, return the kth row of the Pascal's triangle.
//
// For example, given k = 3,
// Return [1,3,3,1]. 
//
//

using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    // 34 / 34 test cases passed.
    //  Status: Accepted
    //  Runtime: 392 ms
    //      
    //      Submitted: 0 minutes ago
    //
    // Hohohoooly shit this is slow
    //
    public static IList<int> GetRow(int rowIndex) {
        return Enumerable.Repeat(1, rowIndex).Aggregate(new List<int>() { 1 },
               (agg, x) => {
                    List<int> result = new List<int>() { 1 };
                    for (int i = 0; i < agg.Count - 1; i++) {
                        result.Add(agg[i] + agg[i + 1]);
                    }

                    result.Add(1);
                    return result;
               });
    }
    
    // 34 / 34 test cases passed.
    //  Status: Accepted
    //  Runtime: 436 ms
    //      
    //      Submitted: 0 minutes ago
    //
    //      Really fucking slow
    public static IList<int> GetRow_2(int rowIndex) {
        List<int> result = new List<int>() { 1 };
        for (int i = 0 ; i < rowIndex; i++) {
            int prev = result[0];
            for (int k = 1; k < result.Count; k ++) {
                int aux = result[k];
                result[k] += prev;
                prev = aux;
            }

            result.Add(1);
        }

        return result;
    }

    static void Main() {
        for (int i = 0; i < 10; i++) {
            Console.WriteLine(String.Join(",", GetRow_2(i)));
        }
    }
}
