#   https://leetcode.com/problems/search-insert-position/
#   Given a sorted array and a target value, return the index if the target is found.
#   If not, return the index where it would be if it were inserted in order.
#
#   You may assume no duplicates in the array.
#   https://leetcode.com/submissions/detail/54941335/

def search_insert(nums, target)
    low = 0
    high = nums.size
    while low < high
        mid = low + (high - low) / 2
        return mid if nums[mid] == target
        if nums[mid] < target
            low = mid + 1
        else
            high = mid
        end
    end
    
    return low
end

#   https://leetcode.com/submissions/detail/57269455/
#   It's evolution, baby!
def search_insert(nums, target)
    low = 0
    high = nums.size
    while low < high
        mid = low + (high - low) / 2
        if nums[mid] < target
            low = mid + 1
        else
            high = mid
        end
    end
    
    low
end
