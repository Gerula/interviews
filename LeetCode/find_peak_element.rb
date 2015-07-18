# Find Peak Element Total Accepted: 31980 Total Submissions: 101216
#
# A peak element is an element that is greater than its neighbors.
#
# Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.
#
# The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
#
# You may imagine that num[-1] = num[n] = -∞.
#
# For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.

def find_peak_element(nums)
    low = 0
    a = nums
    high = nums.size
    while low < high
        mid = low + (high - low) / 2
        if (mid == 0 || a[mid - 1] < a[mid]) && (mid == a.size - 1 || a[mid] > a[mid + 1])
            return mid
        end

        if mid > 0 && a[mid - 1] > a[mid]
            high = mid 
        else
            low = mid + 1
        end
    end

    return 0
end

puts find_peak_element([1, 2, 3, 1])
puts find_peak_element([1, 3, 2, 1])
puts find_peak_element([3, 2, 1])
puts find_peak_element([1, 2, 3])

# 58 / 58 test cases passed.
#   Status: Accepted
#   Runtime: 84 ms
#       
#       Submitted: 0 minutes ago
#





