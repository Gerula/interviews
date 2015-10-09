// http://www.geeksforgeeks.org/find-three-closest-elements-from-given-three-sorted-arrays/
//
//
// Find three closest elements from given three sorted arrays
//
// Given three sorted arrays A[], B[] and C[], find 3 elements i, j and k from A, B and C
// respectively such that max(abs(A[i] – B[j]), abs(B[j] – C[k]), abs(C[k] – A[i])) is minimized.

using System;

class Program 
{
    static Tuple<int, int, int> ThreeClosest(int[] a, int[] b, int[] c)
    {
        int i = 0, 
            j = 0, 
            k = 0;

        int minDiff = int.MaxValue;
        Tuple<int, int, int> result = Tuple.Create(0, 0, 0);

        while (i < a.Length && j < b.Length && k < c.Length)
        {
            int max = Math.Max(Math.Max(a[i], b[j]), c[k]);
            int min = Math.Min(Math.Min(a[i], b[j]), c[k]);
            if (max - min < minDiff)
            {
                minDiff = max - min;
                result = Tuple.Create(a[i], b[j], c[k]);
            }

            if (a[i] == min) 
            {
                i++;
            }
            else
            if (b[j] == min) 
            {
                j++;
            }
            else
            if (c[k] == min) 
            {
                k++;
            }
        }

        return result;
    }

    static void Main()
    {
        if (!Tuple.
            Create(10, 15, 10).
            Equals(ThreeClosest(
                    new [] {1, 4, 10},
                    new [] {2, 15, 20},
                    new [] {10, 12})))
        {
            throw new Exception("No no no no no no!!");
        }

        if (!Tuple.
            Create(24, 22, 23).
            Equals(ThreeClosest(
                    new [] {20, 24, 100},
                    new [] {2, 19, 22, 79, 800},
                    new [] {10, 12, 23, 24, 119})))
        {
            throw new Exception("No no no no no no!!");
        }

        Console.WriteLine("All appears to be well");
    }
}
