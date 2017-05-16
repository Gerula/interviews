//  https://leetcode.com/problems/russian-doll-envelopes/
//  You have a number of envelopes with widths and heights given as a pair of integers (w, h). One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.
//
//  What is the maximum number of envelopes can you Russian doll? (put one inside other)
//
//  Example:
//  Given envelopes = [[5,4],[6,4],[6,7],[2,3]], the maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]). 

//  HA! Accepted. It was the linq part that was holding up the awesomeness
//  https://leetcode.com/submissions/detail/63692014/
//  
//  Submission Details
//  85 / 85 test cases passed.
//      Status: Accepted
//      Runtime: 744 ms
//          
//          Submitted: 0 minutes ago
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
        var localMax = 0;
        for (var j = 0; j < i; j++) {
            if (dolls[j].Item1 < dolls[i].Item1 && 
                dolls[j].Item2 < dolls[i].Item2 &&
                dp[j] > localMax) {
                    localMax = dp[j];
                }    
        }
        
        dp[i] = localMax + 1;
        max = Math.Max(max,  dp[i]);
    }    

    return max;
}

