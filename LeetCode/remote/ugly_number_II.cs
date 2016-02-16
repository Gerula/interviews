//  https://leetcode.com/problems/ugly-number-ii/
//
//   Write a program to find the n-th ugly number.
//
//   Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.
//   For example, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
//
//   Note that 1 is typically treated as an ugly number. 

//  https://leetcode.com/submissions/detail/53584642/
//
//  Submission Details
//  596 / 596 test cases passed.
//      Status: Accepted
//      Runtime: 104 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public int NthUglyNumber(int n) {
        var factors = new [] { 0, 0, 0 };
        if (n <= 1)
        {
            return 1;
        }
        
        var result = new int[n + 1];
        result[0] = 1;
        for (var i = 1; i <= n; i++)
        {
            result[i] = new [] { result[factors[0]] * 2, result[factors[1]] * 3, result[factors[2]] * 5 }.Min();
            if (result[factors[0]] * 2 == result[i])
            {
                factors[0]++;
            }
            if (result[factors[1]] * 3 == result[i])
            {
                factors[1]++;
            }
            if (result[factors[2]] * 5 == result[i])
            {
                factors[2]++;
            }
        }
        
        return result[n - 1];
    }
}
