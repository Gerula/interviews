//  https://leetcode.com/problems/powx-n/
//
//  Implement pow(x, n). 

public class Solution {
    //  
    //  Submission Details
    //  299 / 299 test cases passed.
    //      Status: Accepted
    //      Runtime: 68 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49627092/
    //
    public double MyPow(double x, int n) {
        if (n == 0)
        {
            return 1;
        }
        
        if (n == 1)
        {
            return x;
        }
        
        if (n < 0)
        {
            n = -n;
            x = 1 / x;
        }
        
        if (n % 2 == 0)
        {
            return MyPow(x * x, n / 2);
        }
        
        return x * MyPow(x * x, n / 2);
    }
}
