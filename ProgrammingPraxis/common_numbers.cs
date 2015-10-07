// http://programmingpraxis.com/2015/03/17/common-elements-of-three-arrays/
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static List<int> CommonElements(this List<int[]> lists)
    {
        byte i = 0;
        return lists.Aggregate(new Dictionary<int, byte>(), 
                               (acc, x) => {
                                    x.Aggregate(acc, 
                                                (a, b) => {
                                                    if (!a.ContainsKey(b))
                                                    {
                                                        a[b] = 0;
                                                    }

                                                    a[b] |= (byte)(1 << i);
                                                    return a;
                                                });

                                    i++;
                                    return acc;
                               }).
                               Where(y => y.Value == (1 << lists.Count) - 1).
                               Select(z => z.Key).
                               ToList();
    }

    static List<int> CommonElementsBetter(this List<int[]> lists)
    {
        var listOfLists = lists.Select(x => new List<int>(x));
        return listOfLists.Aggregate(listOfLists.First(), (agg, x) =>
                                                         {
                                                                List<int> temp = new List<int>();
                                                                InCommonWith(agg, x, temp);
                                                                return temp;
                                                         });
    }

    static void InCommonWith(IEnumerable<int> first, IEnumerable<int> second, List<int> result)
    {
        if (!first.Any() || !second.Any())
        {
            return;
        }

        if (first.First() == second.First())
        {
            result.Add(first.First());
            InCommonWith(first.Skip(1), second.Skip(1), result);
            return;
        }

        if (first.First() < second.First())
        {
            InCommonWith(first.Skip(1), second, result);
        }
        else
        {
            InCommonWith(first, second.Skip(1), result);
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(",",
                          new List<int[]> {
                            new int[] {1, 2, 3, 4, 5, 6},
                            new int[] {1, 2, 3, 4, 5, 6},
                            new int[] {1, 2, 3},
                            new int[] {2, 3, 4},
                            new int[] {1, 2, 3, 4, 5, 6}
                          }.CommonElements()));

        Console.WriteLine(String.Join(",",
                          new List<int[]> {
                            new int[] {1, 2, 3, 4, 5, 6},
                            new int[] {1, 2, 3, 4, 5, 6},
                            new int[] {1, 2, 3},
                            new int[] {2, 3, 4},
                            new int[] {1, 2, 3, 4, 5, 6}
                          }.CommonElementsBetter()));
    }
}
