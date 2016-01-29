//  https://leetcode.com/problems/expression-add-operators/
//
//   Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.
//
//   Examples:
//
//   "123", 6 -> ["1+2+3", "1*2*3"] 
//   "232", 8 -> ["2*3+2", "2+3*2"]
//   "105", 5 -> ["1*0+5","10-5"]
//   "00", 0 -> ["0+0", "0-0", "0*0"]
//   "3456237490", 9191 -> []

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    class Result
    {
        public long Total { get; set; }
        public long FirstTerm { get; set; }
        public String Expression { get; set; }
    }

    public IList<string> AddOperators(string num, int target) 
    {
        return OpWillDeliver(num, 0, new Dictionary<int, IList<Result>>())
               .Where(x => x.Total == target)
               .Select(x => x.Expression)
               .ToList();
    }

    private IList<Result> OpWillDeliver(string num, int index, Dictionary<int, IList<Result>> cache)
    {
        if (cache.ContainsKey(index))
        {
            return cache[index];
        }

        if (num.Length - 1 == index)
        {
            var partial = num.Substring(index);
            cache[index] = new List<Result> { 
                new Result {
                    Total = long.Parse(partial),
                    FirstTerm = long.Parse(partial),
                    Expression = partial
                } 
            };

            return cache[index];
        }
        
        var result = new List<Result>();
        for (var len = 1; len <= num.Length - (index + len) + 1; len++)
        {
            var local = long.Parse(num.Substring(index, len));
            foreach (var next in  OpWillDeliver(num, index + len, cache))
            {
                result.Add(new Result {
                            Total = local + next.Total,
                            FirstTerm = local,
                            Expression = String.Format("{0}+{1}", local, next.Expression)
                        });
                result.Add(new Result {
                            Total = local + next.Total - 2 * next.FirstTerm,
                            FirstTerm = local,
                            Expression = String.Format("{0}-{1}", local, next.Expression)
                        });
                result.Add(new Result {
                            Total = local * next.FirstTerm + next.Total - next.FirstTerm,
                            FirstTerm = local * next.FirstTerm,
                            Expression = String.Format("{0}*{1}", local, next.Expression)
                        });
            }

            if (num[index] == '0')
            {
                break;
            }
        }

        cache[index] = result;
        return cache[index];
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in new [] {
                    Tuple.Create("123", 6),
                    Tuple.Create("232", 8),
                    Tuple.Create("105", 5),
                    Tuple.Create("00", 0),
                })
        {
            Console.WriteLine("[{0}] - {1}", x, String.Join(", ", s.AddOperators(x.Item1, x.Item2)));
        }
    }
}
