# Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times. The algorithm should run in linear time and in O(1) space.
#
# 64 / 64 test cases passed.
#   Status: Accepted
#   Runtime: 104 ms
#       
#       Submitted: 0 minutes ago
#

def majority_element(nums)
    majority_1 = nil
    majority_2 = nil
    count_1 = 0
    count_2 = 0
    nums.each { |x|
        if count_1 == 0 || x == majority_1
            count_1 += 1
            majority_1 = x
        elsif count_2 == 0 || x == majority_2
            count_2 += 1
            majority_2 = x
        else
            count_1 -= 1
            count_2 -= 1
        end
    }

    result = []
    if nums.count{ |x| x == majority_1 } > nums.size / 3
        result << majority_1 unless majority_1.nil?
    end
    if majority_1 != majority_2 && nums.count{ |x| x == majority_2 } > nums.size / 3
        result << majority_2 unless majority_2.nil?
    end

    result
end

# Time limit exceeded
#
def majority_element_2(nums)
    nums.select { |x| nums.count{ |y| y == x} > nums.size / 3}.uniq
end

# 64 / 64 test cases passed.
#   Status: Accepted
#   Runtime: 120 ms
#       
#       Submitted: 1 minute ago
#
def majority_element_3(nums)
     majority = nums.size / 3
     result = []
     counts = nums.inject({}) { |acc, n| 
        acc[n] ||= 0
        acc[n] += 1
        if acc[n] > majority && !result.include?(n)
            result << n
        end
        
        acc
     }
     
     return result
end

puts majority_element([1, 2, 1, 3, 2, 1]).inspect
puts majority_element([0,-1,2,-1]).inspect
puts majority_element_2([1, 2, 1, 3, 2, 1]).inspect
puts majority_element_2([0,-1,2,-1]).inspect

