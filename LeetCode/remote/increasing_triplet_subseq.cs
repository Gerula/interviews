//  https://leetcode.com/problems/increasing-triplet-subsequence/
//
//   Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array.
//
//   Formally the function should:
//
//       Return true if there exists i, j, k
//       such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false. 
//
//   Your algorithm should run in O(n) time complexity and O(1) space complexity. 
//
//   https://leetcode.com/submissions/detail/53633813/
//
//   Submission Details
//   61 / 61 test cases passed.
//      Status: Accepted
//      Runtime: 152 ms
//          
//          Submitted: 1 minute ago
//  What a fucking weird problem..

public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        var one = int.MaxValue;
        var two = int.MaxValue;
        foreach (var x in nums)
        {
            if (x <= one)
            {
                one = x;
            } 
            else if (x <= two)
            {
                two = x;
            }
            else 
            {
                return true;
            }
        }
        
        return false;
    }
}
