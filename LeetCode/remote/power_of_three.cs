//   Given an integer, write a function to determine if it is a power of three.
//
//   Follow up:
//   Could you do it without using any loop / recursion? 

public class Solution {
    //  
    //  Submission Details
    //  21016 / 21016 test cases passed.
    //      Status: Accepted
    //      Runtime: 284 ms
    //          
    //          Submitted: 4 minutes ago
    //
    public bool IsPowerOfThree(int n) {
        if (n <= 0)
        {
            return false;
        }
        
        return 1162261467 % n == 0;
    }
}
