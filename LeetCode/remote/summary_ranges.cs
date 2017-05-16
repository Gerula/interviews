//  https://leetcode.com/problems/summary-ranges/
//
//   Given a sorted integer array without duplicates, return the summary of its ranges.
//
//   For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"]. 

public class Solution {
    //  
    //  Submission Details
    //  27 / 27 test cases passed.
    //      Status: Accepted
    //      Runtime: 468 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52549961/
    //
    public IList<string> SummaryRanges(int[] nums) {
        return nums.Aggregate(
                new List<Tuple<int, int>>(), 
                (acc, x) => {
                    if (!acc.Any() || acc.Last().Item2 != x - 1)
                    {
                        acc.Add(Tuple.Create(x, x));
                    }
                    else
                    {
                        acc[acc.Count - 1] = Tuple.Create(acc.Last().Item1, x);
                    }
                    
                    return acc;
                })
                .Select(x => x.Item1 == x.Item2 ? x.Item1.ToString() : String.Format("{0}->{1}", x.Item1, x.Item2))
                .ToList();
    }
}

//  All hail to the coding olympics. Same exact fucking thing
//  
//  Submission Details
//  27 / 27 test cases passed.
//      Status: Accepted
//      Runtime: 516 ms
//          
//          Submitted: 0 minutes ago
//  Only slower.. actually either they are cheaping out on compute capacity (highly unlikely) or there are many more people doing this.
public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        return nums
               .Aggregate(
                   new List<Tuple<int, int>>(),
                   (acc, x) => {
                        if (!acc.Any() || acc.Last().Item2 + 1 != x)
                        {
                            acc.Add(Tuple.Create(x, x));
                        }
                        else
                        {
                            acc[acc.Count - 1] = Tuple.Create(acc[acc.Count - 1].Item1, x);
                        }
                        
                        return acc;
                   })
               .Select(x => x.Item1 == x.Item2 ? 
                                x.Item1.ToString() :
                                String.Format("{0}->{1}", x.Item1, x.Item2))
               .ToList();
    }
}
