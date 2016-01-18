//  https://leetcode.com/problems/reverse-bits/
// Reverse bits of a given 32 bits unsigned integer.
//
// For example, given input 43261596 (represented in binary as 00000010100101000001111010011100),
// return 964176192 (represented in binary as 00111001011110000010100101000000).

using System;

public class Solution {
    //  
    //  Submission Details
    //  600 / 600 test cases passed.
    //      Status: Accepted
    //      Runtime: 56 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/51016416/
    //
    //  You are here!
    //  Your runtime beats 95.40% of csharp submissions.
    public uint reverseBits(uint n) {
        var max = 32;
        for (var i = 0; i < max / 2; i++)
        {
            if (((n >> i) & 1) != ((n >> (max - i - 1) & 1)))
            {
                n ^=  ((uint)1 << i) | ((uint)1 << (max - i - 1));
            }
        }
        
        return n;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().reverseBits(1));
        Console.WriteLine(new Solution().reverseBits(4294967295));
    }
}
