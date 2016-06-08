//  https://leetcode.com/problems/russian-doll-envelopes/
//  You have a number of envelopes with widths and heights given as a pair of integers (w, h). One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.
//
//  What is the maximum number of envelopes can you Russian doll? (put one inside other)
//
//  Example:
//  Given envelopes = [[5,4],[6,4],[6,7],[2,3]], the maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]). 

//  TLE Solutionc class Solution {
public int MaxEnvelopes(int[,] envelopes) {
    if (envelopes.GetLength(0) == 0)
    {
        return 0;
    }
    
    var dolls = Enumerable
                .Range(0, envelopes.GetLength(0))
                .Select(x => Tuple.Create(envelopes[x, 0], envelopes[x, 1], envelopes[x, 0] * envelopes[x, 1]))
                .OrderBy(x => x.Item3)
                .ToArray();

    var dp = new int[dolls.Length];
    dp[0] = 1;
    var max = 1;
    for (var i = 1; i < dolls.Length; i++) {
        dp[i] = Enumerable
                .Range(0, i)
                .Where(x => dolls[x].Item1 < dolls[i].Item1 && dolls[x].Item2 < dolls[i].Item2)
                .Select(x => dp[x])
                .DefaultIfEmpty(0)
                .Max() + 1;
        max = Math.Max(max,  dp[i]);
    }
    
    return max;
}

