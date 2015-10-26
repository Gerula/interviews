// http://careercup.com/question?id=5756151524229120
//
// Given an array A and an array of indexes B, reorder
// objects in A.
//
// a = { "c", "d", "e", "f", "g"]
// b = { 3, 0, 4, 1, 2 ]
//
// result : = ["d", "f", "g", "c", "e"]
//

using System;
using System.Linq;

static class Program 
{
    static char[] Permute(this char[] a, int[] permutation)
    {   
        for (int i = 0; i < a.Length; i++)
        {
            int position = i;
            char current = a[i];
            while (permutation[position] >= 0)
            {
                char next = a[permutation[position]];
                int nextPosition = permutation[position];
                a[permutation[position]] = current;
                permutation[position] = -1;
                position = nextPosition;
                current = next; 
            }
        }

        return a;
    }

    static void Main()
    {
        if (!new [] { 'c', 'd', 'e', 'f', 'g' }.
                Permute(new [] { 3, 0, 4, 1, 2 }).
                SequenceEqual(new [] { 'd' , 'f', 'g', 'c', 'e' }))
        {
            throw new Exception(String.Format("You're not good enough {0}", String.Join(", ", new [] { 'c', 'd', 'e', 'f', 'g' }.Permute(new [] { 3, 0, 4, 1, 2 }))));
        }

        Console.WriteLine("All appears to be well");
    }
}

