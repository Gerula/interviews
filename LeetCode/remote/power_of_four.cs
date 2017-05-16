//  https://leetcode.com/problems/power-of-four/
//  https://leetcode.com/submissions/detail/60533792/
//  
//  Submission Details
//  1060 / 1060 test cases passed.
//      Status: Accepted
//      Runtime: 68 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public bool IsPowerOfFour(int num) {
        return num > 0 && (num & (num - 1)) == 0 && (num - 1) % 3 == 0;
    }
}
