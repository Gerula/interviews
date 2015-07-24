# https://leetcode.com/submissions/detail/33983893/

# @param {Integer[]} nums
# @return {Integer}
def longest_consecutive(nums)
    hash = nums.inject({}) { |acc, x|
        acc[x] = true
        acc
    }
    
    max = 0
    nums.each { |x|
       count = 1 
       num = x - 1
       while hash[num]
           count += 1
           hash.delete(num)
           num -= 1
       end
       num = x + 1
       while hash[num]
           count += 1
           hash.delete(num)
           num += 1
       end
       max = [count, max].max
    }

    return max
end
