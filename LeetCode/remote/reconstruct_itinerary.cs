//  https://leetcode.com/problems/reconstruct-itinerary/
//
//  Given a list of airline tickets represented by pairs of departure and arrival airports [from, to],
//  reconstruct the itinerary in order.
//
//  All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.
//
//  Note:
//
//  If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string.
//  For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
//
//  All airports are represented by three capital letters (IATA code).
//  
//  You may assume all tickets may form at least one valid itinerary.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<string> FindItinerary(string[,] tickets) { // What a fucking pedestrian way to encapsulate an adjacency list
        var nexts = Enumerable
                    .Range(0, tickets.GetLength(0))
                    .Aggregate(
                            new Dictionary<String, SortedSet<String>>(),
                            (acc, x) => {
                                var src = tickets[x, 0];
                                var dest = tickets[x, 1];
                                if (!acc.ContainsKey(src))
                                {
                                    acc[src] = new SortedSet<String>();
                                }

                                acc[src].Add(dest);
                                return acc;
                            });

        var stack = new Stack<String>();
        var start = "JFK";
        stack.Push(start);
        var result = new List<String>();

        while (stack.Any())
        {
            while (nexts.ContainsKey(stack.Peek()) &&
                   nexts[stack.Peek()].Any())
            {
                var next = nexts[stack.Peek()].Min;
                nexts[stack.Peek()].Remove(next);
                stack.Push(next);
            }

            result.Add(stack.Pop());
        }

        result.Reverse();
        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().FindItinerary(new [,] {{"MUC", "LHR"}, {"JFK", "MUC"}, {"SFO", "SJC"}, {"LHR", "SFO"}})));
        Console.WriteLine(String.Join(", ", new Solution().FindItinerary(new [,] {{"JFK","KUL"}, {"JFK","NRT"}, {"NRT","JFK"}}))); 
        Console.WriteLine(String.Join(", ", new Solution().FindItinerary(new [,] {{"EZE","AXA"},{"TIA","ANU"},{"ANU","JFK"},{"JFK","ANU"},{"ANU","EZE"},{"TIA","ANU"},{"AXA","TIA"},{"TIA","JFK"},{"ANU","TIA"},{"JFK","TIA"}})));
        Console.WriteLine(String.Join(", ", new Solution().FindItinerary(new [,] {{"JFK","SFO"}, {"JFK","ATL"}, {"SFO","ATL"}, {"ATL","JFK"}, {"ATL","SFO"}})));
    }
}
