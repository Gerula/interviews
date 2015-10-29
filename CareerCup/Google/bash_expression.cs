// http://careercup.com/question?id=5717301963784192
//
// Write code that could parse an expression like a bash
// brace expansion. 
//
// For example 
// 
// (a,b,cy)n,m
//
// should output { "an", "bn", "cyn", "m" }
//
// ((a,b)o(m,n)p,b) == { "aomp", "aonp", "bomp", "bonp", "b" }
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static List<String> Parse(this String s)
    {
        int start = 0;
        return s.Parse(ref start);
    }

    static List<String> Parse(this String s, ref int start)
    {
        var result = new List<String>();
        var elements = new List<String>();
        elements.Add(String.Empty);

        while (start < s.Length)
        {
            char symbol = s[start];
            start++;
            switch (symbol)
            {
                case '(': {
                              var newElements = new List<String>();
                              var insideElements = s.Parse(ref start);
                              foreach (var insideElement in insideElements)
                              {
                                  newElements.AddRange(elements.Select(x => x + insideElement));
                              }

                              elements.Clear();
                              elements.AddRange(newElements);
                          }
                          break;

                case ')': {   // Evacuate and return
                              result.AddRange(elements);
                              return result;
                          }
                case ',': {   // Evacuate the current elements into the result
                              result.AddRange(elements);
                              elements.Clear();
                              elements.Add(String.Empty);
                          }
                          break;
                default:  {   // Add to current elements. Like (x, y, z)a will add a to all of the symbols
                              // inside the parentheses
                              elements = elements.ConvertAll(x => x + symbol);
                          }
                          break;
            }
        }

        result.AddRange(elements);
        return result;
    }

    static void Main()
    {
        new [] {
            Tuple.Create(
                    "(a,b,cy)n,m",
                    new [] { "an", "bn", "cyn", "m" }),
            Tuple.Create(
                    "((a,b)o(m,n)p,b)",
                    new [] { "aomp", "bomp", "aonp", "bonp", "b" })
        }.
        ToList().
        ForEach(x => {
                    var result = x.Item1.Parse();
                    if (!result.SequenceEqual(x.Item2))
                    {
                        throw new Exception(String.Format(
                                "Idiot you are. [{0}] vs [{1}]",
                                String.Join(", ", result),
                                String.Join(", ", x.Item2)
                                ));
                    }
                });

        Console.WriteLine("All appears to be well");
    }
}

