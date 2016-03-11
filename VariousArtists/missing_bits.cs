//  I don't recall the url or exact problem statement but it goes something like this:
//
//  A sequence of bits is missing some elements, marked as ?. Generate all possible
//  sequences to help reconstruct the original sequence.

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution {
    static IEnumerable<String> Regenerate(this String s) {
        if (String.IsNullOrEmpty(s)) {
            return new [] { "" }.AsEnumerable();
        }

        return s
               .Substring(1)
               .Regenerate()
               .SelectMany(next => (s[0] == '?' ? 
                           new [] { "1", "0" }.AsEnumerable() :
                           new [] { s[0].ToString() }.AsEnumerable()),
                           (x, y) => {
                                return String.Format("{0}{1}", y, x);
                           });
    }

    static void Main() {
        Console.WriteLine(
                String.Join(
                    Environment.NewLine,
                    new [] {"1?1", "???", "0?0?1?1??"}
                    .Select(x => String.Format("{0} - {1}", x, String.Join(", ", x.Regenerate())))));
    }
}
