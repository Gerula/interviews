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

//  It's evolution baby! (they added another test for overflow - the above solution doesn't work anymore)
//  https://leetcode.com/submissions/detail/59365036/
//
//  Submission Details
//  300 / 300 test cases passed.
//      Status: Accepted
//      Runtime: 80 ms
//          
//          Submitted: 0 minutes ago
//
public class Solution {
    public double MyPow(double x, int n) {
        if (n == 0)
        {
            return 1;
        }
        
        if (n == 1)
        {
            return x;
        }
        
        if (n == 2)
        {
            return x * x;
        }
        
        var next = n / 2;
        if (n < 0)
        {
            next = -next;
            x = 1 / x;
        }
        
        var sub = MyPow(x, next);
        if (n % 2 == 0)
        {
            return MyPow(sub, 2);
        }
        
        return x * MyPow(sub, 2);
    }
}
