# There are two sorted arrays nums1 and nums2 of size m and n respectively. Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
#

a = [1, 3, 5, 7, 9, 11]
b = [2, 3, 4, 6]

def find_median_sorted_arrays(nums1, nums2)
    left = 0
    right = 0
    threshold = (nums1.size + nums2.size) / 2
    i = 0

    while left < nums1.size || right < nums2.size
        a = (left < nums1.size)? nums1[left] : Fixnum::MAX
        b = (right < nums2.size)? nums2[right] : Fixnum::MAX
        i += 1
        current = 0
        if a < b
            current = nums1[left]
            left += 1
        else
            current = nums1[left]
            right += 1
        end

        if i == threshold
            return current
        end
    end
end

puts find_median_sorted_arrays(a, b)

