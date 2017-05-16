#   https://leetcode.com/problems/search-for-a-range/
#
#   Given a sorted array of integers, find the starting and ending position of a given target value.
#
#   Your algorithm's runtime complexity must be in the order of O(log n).
#
#   If the target is not found in the array, return [-1, -1].
#
#   https://leetcode.com/submissions/detail/54795842/
#
#   Submission Details
#   81 / 81 test cases passed.
#       Status: Accepted
#       Runtime: 80 ms
#           
#           Submitted: 0 minutes ago

def search_range(nums, target)
    left = search(target, nums, :left)
    return [-1, -1] if left == -1
    [left, search(target, nums, :right)]
end

def search(value, nums, direction)
    low = 0
    high = nums.size
    found = -1
    while low < high
        mid = low + (high - low) / 2
        if nums[mid] > value
            high = mid
        elsif nums[mid] < value
            low = mid + 1
        else
            found = mid
            case direction
                when :left  
                    high = mid
                when :right 
                    low = mid + 1
            end
        end
    end
    
    found
end

# Way nicer solution
#   https://leetcode.com/submissions/detail/54795980/
#
#   Submission Details
#   81 / 81 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
def search_range(nums, target)
    left = search(target, nums, :left)
    return [-1, -1] if left == nums.size || target != nums[left]
    [left, search(target + 1, nums, :right) - 1]
end

def search(value, nums, direction)
    low = 0
    high = nums.size
    while low < high
        mid = low + (high - low) / 2
        if nums[mid] < value
            low = mid + 1
        else
            high = mid
        end
    end
    
    low
end

#   It's evolution baby!
#   
#   Submission Details
#   81 / 81 test cases passed.
#       Status: Accepted
#       Runtime: 92 ms
#           
#           Submitted: 0 minutes ago
#
def search_range(nums, target)
    low = search(nums, target)
    nums[low] == target ? [low, search(nums, target + 1) - 1] : [-1, -1] 
end

def search(nums, target)
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
    
    return low
end
