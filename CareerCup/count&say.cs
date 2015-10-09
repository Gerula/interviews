// http://www.careercup.com/question?id=7853661
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static String CountAndSay(int n)
    {
        return String.Join(Environment.NewLine,
                Enumerable.Range(2, n).
                Aggregate(new List<String> {"1"}, (acc, x) => {
                        int currentCount = 0;
                        String last = acc.Last();
                        StringBuilder result = new StringBuilder();
                        for (int i = 0; i < last.Length; i++)
                        {
                            currentCount += 1;
                            if (i == last.Length - 1 || last[i] != last[i + 1])
                            {
                                result.Append(String.Format("{0}{1}", currentCount, last[i]));
                                currentCount = 0;
                            }
                        }

                        acc.Add(result.ToString());
                        return acc;
                    }));
    }

    static void Main()
    {
        Console.WriteLine(CountAndSay(10));
    }
}
