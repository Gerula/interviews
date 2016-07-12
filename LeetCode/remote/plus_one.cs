//  https://leetcode.com/problems/plus-one/
//  https://leetcode.com/submissions/detail/66847531/
//
//  Submission Details
//  108 / 108 test cases passed.
//      Status: Accepted
//      Runtime: 460 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int[] PlusOne(int[] digits) {
        var carry = 1;
        var i = digits.Length - 1;
        while (carry != 0 && i >= 0) {
            carry = Math.DivRem(digits[i] + carry, 10, out digits[i]);
            i--;
        }
        
        return carry == 0 ? digits : new [] { carry }.Concat(digits).ToArray();
    }
}
