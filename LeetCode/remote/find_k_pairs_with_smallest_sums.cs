//  https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
//   You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.
//
//   Define a pair (u,v) which consists of one element from the first array and one element from the second array.
//
//   Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.
//
//   Example 1:
//
//   Given nums1 = [1,7,11], nums2 = [2,4,6],  k = 3
//
//   Return: [1,2],[1,4],[1,6]
//
//   The first 3 pairs are returned from the sequence:
//   [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]

//  TLE ofc
public class Solution {
    public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        return nums1
               .Select(x => nums2.Select(y => new [] {x, y}))
               .SelectMany(x => x)
               .OrderBy(x => x.Sum())
               .Take(k)
               .ToList();
    }
}

//  Stupid solution based on list merge
public class Solution {
    public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        var result = new List<int[]>();
        
        var i = 0;
        var j = 0;
        while (result.Count < k && i < nums1.Length && j < nums2.Length) {
            result.Add(new [] { nums1[i], nums2[j] });
            if (nums1[i] < nums2[j] && j < nums2.Length) {
                j++;
            } else if (i < nums1.Length){
                i++;
            }
        }
        
        return result;
    }
}

//  Intense struggle (and peeked at the solutions)
//  https://leetcode.com/submissions/detail/66472584/
//  
//  Submission Details
//  27 / 27 test cases passed.
//      Status: Accepted
//      Runtime: 668 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        /*
            1   1   2
        1   2   2   3
        2   3   3   4
        3   4   4   5
        
        [1,1],[1,1],[2,1],[1,2],[1,2],[2,2],[1,3],[1,3],[2,3]
        
            1   7   11
        2   3   9   13
        4   5   11  15
        6   7   13  17
        
        [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
        
        */
        
        var graph = new int[nums1.Length, nums2.Length];
        for (var i = 0; i < nums1.Length; i++) {
            for (var j = 0; j < nums2.Length; j++) {
                graph[i, j] = nums1[i] + nums2[j];
            }
        }
        
        var result = new List<int[]>();
        while (result.Count < k) {
            var min = int.MaxValue;
            var indexes = new [] { nums1.Length, nums2.Length };
            for (var i = 0; i < nums1.Length; i++) {
                // Note this shit right here. If it weren't for this, it would have TLEd
                // this takes advantage on the fact that the matrix is already sorted
                // and so it does pruning.
                for (var j = 0; j < indexes[1]; j++) {
                    if (graph[i, j] < min) {
                        min = graph[i, j];
                        indexes = new [] { i, j };
                    } else {
                        continue;
                    }
                }
            }
            
            if (min == int.MaxValue) {
                break;
            }
            
            result.Add(new [] { nums1[indexes[0]], nums2[indexes[1]] });
            graph[indexes[0], indexes[1]] = int.MaxValue;
        }
        
        return result;
    }
}
