// http://www.geeksforgeeks.org/maximum-weight-transformation-of-a-given-string/
//
// Given a string consisting of only A’s and B’s. We can transform the given string to another string by toggling any character. Thus many transformations of the given string are possible. The task is to find Weight of the maximum weight transformation.
// 
// Weight of a sting is calculated using below formula.
// 
// 
// Weight of string = Weight of total pairs + 
//                    weight of single characters - 
//                    Total number of toggles.
// 
// Two consecutive characters are considered as pair only if they 
// are different. 
// Weight of a single pair (both character are different) = 4
// Weight of a single character = 1  

using System;
using System.Collections.Generic;

class Program {
    static int MaxWeight(String s) {
        return 0;
    }

    static void Main() {
        var tests = new [] {
            new { s = "AA", w = 3 },
            new { s = "ABB", w = 5 }
        };

        foreach (var test in tests) {
            if (MaxWeight(test.s) != test.w) {
                throw new Exception("U r dumb!");
            }
        }

        Console.WriteLine("All tests pass");
    }
}
