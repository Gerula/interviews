//  https://leetcode.com/problems/excel-sheet-column-number/
//  I fucking hate this problem
//  https://leetcode.com/submissions/detail/60819887/
//
//  Submission Details
//  1000 / 1000 test cases passed.
//      Status: Accepted
//      Runtime: 136 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int TitleToNumber(string s) {
        return s.Aggregate(0, (acc, x) => acc * 26 + x - 'A' + 1);
    }
}
