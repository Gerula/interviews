//  Given a collection of integers that might contain duplicates, nums, return all possible subsets.
//
//  Note:
//
//      Elements in a subset must be in non-descending order.
//      The solution set must not contain duplicate subsets.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {

    private static void Subsets(List<int> input, int position, List<int> result) {
        Console.WriteLine(String.Join(",", result));

        for (int i=position; i < input.Count; i++)
        {
            if (!result.Any() || result[result.Count - 1] <= input[i]) 
                result.Add(input[i]);
                Subsets(input, i + 1, result);
                result.RemoveAt(result.Count - 1);
            }
        }
    }

    public static void Main(string[] args) {
        List<int> input = new List<int> { 1, 2, 2 };
        List<int> result = new List<int> ();
        Subsets(input, 0, result);
    }
}
