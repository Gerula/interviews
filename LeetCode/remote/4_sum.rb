# https://leetcode.com/submissions/detail/34103070/ 

def four_sum(nums, target)
    nums.sort!
    result = []
    0.upto(nums.size - 1).each { |i|
        target_i = target - nums[i]
        (i + 1).upto(nums.size - 1).each { |j|
            target_j = target_i - nums[j]
            k = j + 1
            l = nums.size - 1
            while k < l
                sum = nums[k] + nums[l]
                k += 1 if sum < target_j 
                l -= 1 if sum > target_j
                if sum == target_j
                    result << [nums[i], nums[j], nums[k], nums[l]] 
                    while k < l && nums[k] == result.last[2]
                        k += 1
                    end
                    while k < l && nums[l] == result.last[3]
                        l -= 1
                    end
                end
            end
        }
    }
    
    return result.uniq
end
