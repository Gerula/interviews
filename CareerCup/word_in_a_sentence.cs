// http://careercup.com/question?id=6273553081040896
//
// Given a string containing a sentence and two words
// print the min distance between the two words.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int MinDistance(this String sentence, String first, String second)
    {
        var positions = sentence.
                            Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).
                            Select((word, index) => new { word, index}).
                            Aggregate(new Dictionary<String, List<int>>(),
                                      (agg, w) => {
                                        if (!agg.ContainsKey(w.word)) 
                                        {
                                            agg[w.word] = new List<int>();
                                        }

                                        agg[w.word].Add(w.index);
                                        return agg;
                                      });

        var firstPositions = positions[first];
        var secondPositions = positions[second];
        var i = 0;
        var j = 0;
        var min = int.MaxValue;
        while (i < firstPositions.Count && j < secondPositions.Count)
        {
            if (firstPositions[i] == secondPositions[j])
            {
                i++;
            }
            else if (firstPositions[i] < secondPositions[j])
            {
                min = Math.Min(secondPositions[j] - firstPositions[i], min);
                i++;
            }
            else
            {
                min = Math.Min(firstPositions[i] - secondPositions[j], min);
                j++;
            }
        }

        return min;
    }

    static void Main()
    {
        Console.WriteLine("The brown quick fox quick the".MinDistance("the", "quick"));
        Console.WriteLine("the brown the quick fox quick the".MinDistance("the", "the"));
    }
}
