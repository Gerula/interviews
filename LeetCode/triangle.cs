// Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
//
// For example, given the following triangle
//
// [
//   [2],
//   [3,4],
//   [6,5,7],
//   [4,1,8,3]
// ]
//
// The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11). 
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {

    private static int Ninja(List<List<int>> triangle) {
       return Enumerable.Range(1, triangle.Count - 1)
                        .Aggregate(triangle[0],(a, b) => {
                                   List<int> result = new List<int>(triangle[b]); 
                                   for (int i = 0; i < result.Count; i++)
                                   {
                                        int first = i == 0 ? int.MaxValue : a[i - 1]; 
                                        int second = i == result.Count - 1 ? int.MaxValue : a[i];
                                        result[i] += Math.Min(first, second);
                                   }

                                   return result;
                                } ).Min();
    }

    public static void Main(string[] args) {
        List<List<int>> triangle = new List<List<int>>();
        triangle.Add(new List<int> { 2 } );
        triangle.Add(new List<int> { 3, 4 } );
        triangle.Add(new List<int> { 6, 5, 7 } );
        triangle.Add(new List<int> { 4, 1, 8, 3 } );
    
        Console.WriteLine(Ninja(triangle));    

        for (int i = 1; i < triangle.Count; i++)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                int first = j == 0 ? int.MaxValue : triangle[i - 1][j - 1]; 
                int second = j == triangle[i].Count - 1 ? int.MaxValue : triangle[i - 1][j];
                triangle[i][j] += Math.Min(first, second);
            }
        }

        Console.WriteLine(triangle.Last().Min());
    }
}

