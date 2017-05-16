#    https://leetcode.com/problems/sort-colors/
#
#    Given an array with n objects colored red,
#    white or blue, sort them so that objects of the same color are adjacent,
#    with the colors in the order red, white and blue.
#
#    Here, we will use the integers 0, 1, and 2 to represent the color
#    red, white, and blue respectively. 
#    https://leetcode.com/submissions/detail/57561223/
#
#    Submission Details
#    86 / 86 test cases passed.
#       Status: Accepted
#       Runtime: 68 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 91.67% of rubysubmissions.
def sort_colors(nums)
    low, mid, high = 0, 0, nums.size
    while mid < high
        case nums[mid]
            when 0
                nums[low], nums[mid] = nums[mid], nums[low]
                low += 1
                mid += 1
            when 1
                nums[low], nums[mid] = nums[mid], nums[low]
                mid += 1
            when 2
                high -= 1
                nums[mid], nums[high] = nums[high], nums[mid]
        end
    end
end

