//  https://leetcode.com/problems/excel-sheet-column-title/
//  Fucking hate this problem
//  https://leetcode.com/submissions/detail/60819250/
//
//  Submission Details
//  18 / 18 test cases passed.
//      Status: Accepted
//      Runtime: 48 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public string ConvertToTitle(int n) {
        var sb = new StringBuilder();
        while (n != 0)
        {
            n--;
            var div = n / 26;
            var mod = n % 26;
            sb.Append((char)('A' + mod));
            n = div;
        }

        var array = sb.ToString().ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }
}
