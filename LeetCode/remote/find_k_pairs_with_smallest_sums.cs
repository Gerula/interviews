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

