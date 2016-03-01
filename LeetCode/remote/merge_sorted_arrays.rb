#   https://leetcode.com/problems/merge-sorted-array/
#   Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
#   https://leetcode.com/submissions/detail/54943543/
def merge(nums1, m, nums2, n)
    last = m + n - 1
    infinity = -2 ** (0.size * 8 - 1)
    m -= 1
    n -= 1
    while last >= 0
        first = m < 0 ? infinity : nums1[m]
        second = n < 0 ? infinity : nums2[n]
        if first > second
            nums1[last] = nums1[m]
            m -= 1
        else
            nums1[last] = nums2[n]
            n -= 1
        end
        
        last -= 1
    end
end


