//  https://leetcode.com/problems/different-ways-to-add-parentheses/
//
//  Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators. The valid operators are +, - and *.
//
//  Example 1
//
//  Input: "2-1-1".
//
//  ((2-1)-1) = 0
//  (2-(1-1)) = 2
//
//  Output: [0, 2]

public class Solution {
    //  
    //  Submission Details
    //  24 / 24 test cases passed.
    //      Status: Accepted
    //      Runtime: 480 ms
    //          
    //          Submitted: 2 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52001382/
    //
    public IList<int> DiffWaysToCompute(string input) {
        var result = new List<int>();

        if (String.IsNullOrEmpty(input))
        {
            return result;
        }
        
        for (var i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
            {
                continue;
            }
         
            foreach (var left in DiffWaysToCompute(input.Substring(0, i)))
            {
                foreach (var right in DiffWaysToCompute(input.Substring(i + 1)))
                {
                    switch (input[i])
                    {
                        case '+': result.Add(left + right); break;
                        case '-': result.Add(left - right); break;
                        case '*': result.Add(left * right); break;
                        default: break;
                    }
                }
            }
        }
        
        if (!result.Any())
        {
            result.Add(int.Parse(input));
        }
        
        return result;        
    }
}
