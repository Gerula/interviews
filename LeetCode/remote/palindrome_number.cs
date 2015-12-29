//  https://leetcode.com/problems/palindrome-number/
//  
//  Determine whether an integer is a palindrome. Do this without extra space.

using System;

public class Solution {
    //  
    //  Submission Details
    //  11506 / 11506 test cases passed.
    //      Status: Accepted
    //      Runtime: 216 ms
    //          
    //          Submitted: 0 minutes ago
    public bool IsPalindromeOld(int x) {
        if (x < 0)
        {
            return false;
        }

        var ex = x;
        var tens = 1;
        while (ex > 9)
        {
            tens *= 10;
            ex /= 10;
        }

        while (tens != 0)
        {
            if (x / tens % 10 != x % 10)
            {
                return false;
            }
            
            x /= 10;
            tens /= 100;
        }

        return true;
    }

    //  
    //  Submission Details
    //  11506 / 11506 test cases passed.
    //      Status: Accepted
    //      Runtime: 192 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public bool IsPalindrome(int x) 
    {
        if (x < 0 || x != 0 && x % 10 == 0)
        {
            return false;
        }

        var xe = 0;
        while (x > xe)
        {
            xe = xe * 10 + x % 10;
            x /= 10;
        }

        return x == xe || x == xe / 10;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.IsPalindrome(1));
        Console.WriteLine(s.IsPalindrome(10));
        Console.WriteLine(s.IsPalindrome(-1));
        Console.WriteLine(s.IsPalindrome(123));
        Console.WriteLine(s.IsPalindrome(121));
        Console.WriteLine(s.IsPalindrome(12321));
        Console.WriteLine(s.IsPalindrome(-2147447412));
        Console.WriteLine(s.IsPalindrome(1844994481));
    }
}
