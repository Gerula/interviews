//  https://leetcode.com/problems/valid-perfect-square/
//  Given a positive integer num, write a function which returns True if num is a perfect square else False.
//
//  Note: Do not use any built-in library function such as sqrt. 
//
//  https://leetcode.com/submissions/detail/65568729/
//
//  Submission Details
//  66 / 66 test cases passed.
//      Status: Accepted
//      Runtime: 56 ms
//          
//          Submitted: 1 minute ago

public class Solution {
    public bool IsPerfectSquare(int num) {
        var start = 1;
        var end = num;
        while (start < end) {
            var mid = start + (end - start) / 2;
            if (mid < num / mid) {
                start = mid + 1;
            } else {
                end = mid;
            }
        }
        
        return start * start == num;
    }
}
