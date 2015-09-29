// http://careercup.com/question?id=5633053969874944
//
// You are given an array of n unique integer numbers 0 <= x_i < 2 * n
// Print all integers 0 <= x < 2 * n that are not present in this array.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{

    static int[] FindMissing(this int[] array)
    {
        var result = new List<int>();
        var n = array.Length;

        for (int i = 0; i < n;)
        {
            if (array[i] < n && array[i] != i) 
            {
                var aux = array[array[i]];
                array[array[i]] = array[i];
                array[i] = aux;
            }
            else
            {
                i++;
            }
        }

        result.AddRange(array.Select( (v, i) =>
                                      new { val = v, index = i }).
                              Where(x => x.val != x.index).
                              Select(y => y.index));
                                    
        for (int i = 0; i < n;)
        {
            if (array[i] >=n && array[i] != i + n) 
            {
                var aux = array[array[i] - n];
                array[array[i] - n] = array[i];
                array[i] = aux;
            }
            else
            {
                i++;
            }
        }

        result.AddRange(array.Select( (v, i) =>
                                      new { val = v, index = i }).
                              Where(x => x.val != x.index + n).
                              Select(y => y.index + n));

        return result.ToArray();
    }

    static void Main() 
    {
        if (!(new int[] { 0 }).FindMissing().SequenceEqual(new int[] { 1 })) 
        {
            throw new Exception("U r dumb! 1");
        }

        if (!(new int[] { 0, 2, 4}).FindMissing().SequenceEqual(new int[] { 1, 3, 5 })) 
        {
            throw new Exception("U r dumb! 2");
        }

        if (!(new int[] {}).FindMissing().SequenceEqual(new int[] { })) 
        {
            throw new Exception("U r dumb! 3");
        }

        if (!(new int[] { 0, 1, 4, 5 }).FindMissing().SequenceEqual(new int[] { 2, 3, 6, 7 })) 
        {
            throw new Exception("U r dumb! 4");
        }
     }
}
