//  https://leetcode.com/problems/add-binary/
//
//   Given two binary strings, return their sum (also a binary string).
//
//   For example,
//   a = "11"
//   b = "1"
//   Return "100". 

public class Solution {
    //  
    //  Submission Details
    //  294 / 294 test cases passed.
    //      Status: Accepted
    //      Runtime: 144 ms
    //          
    //          Submitted: 3 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52623377/
    public string AddBinary(string a, string b) {
        return Add(a, b, 0);
    }
    
    public string Add(string a, string b, int remainder)
    {
        if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
        {
            if (remainder == 0)
            {
                return String.Empty;
            }
            
            return Add(a, b, remainder / 2) + (remainder % 2).ToString();
        }
        
        var first = String.IsNullOrEmpty(a) ? 0 : a[a.Length - 1] - '0';
        var second = String.IsNullOrEmpty(b) ? 0 : b[b.Length - 1] - '0';
        var localResult = first + second + remainder;
        return Add(String.IsNullOrEmpty(a) ? a : a.Substring(0, a.Length - 1),
                   String.IsNullOrEmpty(b) ? b : b.Substring(0, b.Length - 1),
                   localResult / 2) + (localResult % 2).ToString();
    }
}
