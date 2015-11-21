// http://careercup.com/question?id=15532723
//
// Given n, print numbers in binary from 0 to 2 ^ n - 1 
// in the order where they differ from exactly one bit.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    //        000
    //        001
    //        011
    //        010
    //        100
    //        101
    //        111
    //        110
    static void Gray(this int n)
    {
        var result = Enumerable
                     .Repeat(0, n - 1)
                     .Aggregate(new List<List<int>> { new List<int> {0}, new List<int> {1} },
                                (acc, x) => {
                                    return
                                    acc.Select(y => {
                                        var t = new List<int> { 0 };
                                        t.AddRange(y);
                                        return t;
                                    })
                                    .Concat(acc.Select(z => {
                                                var t = new List<int> { 1 };
                                                t.AddRange(z);
                                                return t;
                                            })
                                            .Reverse()).ToList();
                                });
        
        Console.WriteLine(String.Join(Environment.NewLine, result.Select(x => String.Join(String.Empty, x))));
    }

    static void Main()
    {
        4.Gray();
    }
}

