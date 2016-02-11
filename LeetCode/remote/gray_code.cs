//  https://leetcode.com/problems/gray-code/
//
//  The gray code is a binary numeral system where two successive values differ in only one bit.
//
//  Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code.
//  A gray code sequence must begin with 0.

//  https://leetcode.com/submissions/detail/53173684/
//
//
//  Submission Details
//  12 / 12 test cases passed.
//      Status: Accepted
//      Runtime: 404 ms
//          
//          Submitted: 0 minutes ago
//

public class Solution {
    public IList<int> GrayCode(int n) {
        return n == 0 ? 
               new List<int> { 0 } :
               Enumerable
               .Range(0, n)
               .Aggregate(
                   new List<String> { String.Empty },
                   (acc, x) => {
                       return  acc
                               .Select(a => "0" + a)
                               .Concat(acc
                                       .AsEnumerable()
                                       .Reverse()
                                       .Select(b => "1" + b))
                               .ToList();
                   })
               .Select(x => Convert.ToInt32(x.ToString(), 2))
               .ToList();
    }
}

//  https://leetcode.com/submissions/detail/53176373/
//
//
//  Submission Details
//  12 / 12 test cases passed.
//      Status: Accepted
//      Runtime: 404 ms
//          
//          Submitted: 0 minutes ago
//

public class Solution {
    public IList<int> GrayCode(int n) 
    {
        var result = new List<int> { 0 };
        for (var i = 0; i < n; i++)
        {
            var local = new List<int>();
            for (var j = result.Count - 1; j >= 0; j--)
            {
                local.Add(result.Count + result[j]);
            }
            
            result = result.Concat(local).ToList();
        }
        
        return result;
    }
}
