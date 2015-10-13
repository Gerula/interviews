// http://careercup.com/question?id=5693863291256832
//
// Rearrange chars in a String so that no adjacent chars repeat
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static Random random = new Random();

    static String Rearrange(this String s)
    {
        int maxOccurences = 0;
        var buckets = s.Aggregate(
                            new Dictionary<char, int>(),
                            (acc, x) => {
                                if (!acc.ContainsKey(x))
                                {
                                    acc[x] = 0;
                                }

                                acc[x]++;
                                return acc;
                            }).Aggregate(
                                new Dictionary<int, Queue<char>>(),
                                (acc_2, y) => {
                                    int count = y.Value;
                                    char character = y.Key;
                                    if (!acc_2.ContainsKey(count))
                                    {
                                        acc_2[count] = new Queue<char>();
                                    }

                                    acc_2[count].Enqueue(character);
                                    maxOccurences = Math.Max(maxOccurences, count);
                                    return acc_2;
                                });

        Enumerable.
            Range(1, maxOccurences).
            ToList().
            ForEach(x => 
                    {
                        if (!buckets.ContainsKey(x))
                        {
                            buckets[x] = new Queue<char>();
                        }
                    });

        StringBuilder result = new StringBuilder();
        while (result.Length < s.Length)
        {
            var blackList = new HashSet<char>();
            for (var bucket = maxOccurences; bucket > 0; bucket--)
            {
                if (buckets[bucket].Any())
                {
                    if (blackList.Contains(buckets[bucket].Peek()))
                    {
                        continue;
                    }

                    char current = buckets[bucket].Dequeue();

                    if (result.Length > 0 && result[result.Length - 1] == current)
                    {
                        return String.Format("Can't do it, buddy. '{0}' is the culprit. Did {1} so far. Sorry..", current, result);
                    }

                    result.Append(current);
                    blackList.Add(current);
                    
                    if (bucket == 1)
                    {
                        continue;
                    }

                    buckets[bucket - 1].Enqueue(current);
                }
            }
        }

        return result.ToString();
    }

    static String GenerateString()
    {
        return String.Join(
                String.Empty, 
                Enumerable.
                    Repeat(0, random.Next(20, 30)).
                    Select(x => (char)random.Next('a', 'g')));
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            String s = GenerateString();
            String p = s.Rearrange();
            Console.WriteLine("{0} = {1}", s, p);
        }
    }
}
