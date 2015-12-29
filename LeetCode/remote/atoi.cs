//  https://leetcode.com/submissions/detail/49160906/
//
//  
//  Submission Details
//  1047 / 1047 test cases passed.
//      Status: Accepted
//      Runtime: 144 ms
//          
//          Submitted: 0 minutes ago
//
//          Textbook cupcake.
public class Solution {
    public int MyAtoi(string str) {
        if (String.IsNullOrEmpty(str))
        {
            return 0;
        }
        
        var sign = 1;
        var start = 0;
        str = str.Trim();
        if (str[0] == '-')
        {
            sign = -1;
            start = 1;
        }
        if (str[0] == '+')
        {
            start = 1;
        }
        
        var result = 0;
        for (var i = start; i < str.Length && '0' <= str[i] && str[i] <= '9'; i++)
        {
            if (result > int.MaxValue / 10 || result == int.MaxValue / 10 && str[i] > '7')
            {
                return sign == -1 ? int.MinValue : int.MaxValue;
            }

            result = result * 10 + str[i] - '0';
        }
        
        return sign * result;
    }
}
