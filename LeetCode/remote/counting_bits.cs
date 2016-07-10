//  https://leetcode.com/problems/counting-bits/
//  Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.
//
//  Example:
//  For num = 5 you should return [0,1,1,2,1,2].
//
//  Follow up:
//
//      It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
//      Space complexity should be O(n).
//      Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
//  
//  https://leetcode.com/submissions/detail/66658242/
//
//  Submission Details
//  15 / 15 test cases passed.
//      Status: Accepted
//      Runtime: 544 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int[] CountBits(int num) {
        return Enumerable
               .Range(1, (int)Math.Log(num, 2) + 1)
               .Aggregate(
                   Enumerable.Range(0, 2),
                   (acc, x) => acc.Concat(acc.Select(v => v + 1)))
               .Take(num + 1)
               .ToArray();
    }
}
