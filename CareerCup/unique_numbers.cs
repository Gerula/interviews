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

    static void ProcessRange(List<int> result,
                             int[] array,
                             int offset,
                             Func<int, int, bool> mismatch,
                             Func<int, int, bool> indexMismatch,
                             Func<int, int> selector)
    {
        for (int i = 0; i < array.Length;)
        {
            if (mismatch(array[i], i))
            {
                var aux = array[array[i] - offset];
                array[array[i] - offset] = array[i];
                array[i] = aux;
            }
            else
            {
                i++;
            }
        }

        result.AddRange(array.Select( (v, i) =>
                                      new { val = v, index = i }).
                              Where(x => indexMismatch(x.val, x.index)).
                              Select(y => selector(y.index)));
    }

    static int[] FindMissing(this int[] array)
    {
        var result = new List<int>();
        var n = array.Length;

        ProcessRange(result,
                     array,
                     0,
                     (element, index) => {
                        return element < n && element != index;
                     },
                     (element, index) => {
                        return element != index;
                     },
                     (element) => {
                        return element;
                     });

        ProcessRange(result,
                     array,
                     n,
                     (element, index) => {
                        return element >= n && element != index + n;
                     },
                     (element, index) => {
                        return element != index + n;
                     },
                     (element) => {
                        return element + n;
                     });
                                    
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
