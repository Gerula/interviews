# https://leetcode.com/problems/maximum-gap/submissions/

# @param {Integer[]} nums
# @return {Integer}
def maximum_gap(nums)
    min = nums.min
    max = nums.max
    return 0 if nums.size < 2
    bucket_size = nums.size.to_f / (max - min)
    buckets = []
    nums.each { |x|
        index = ((x - min) * bucket_size).to_i
        buckets[index] ||= [x, x]
        buckets[index][0] = [buckets[index][0], x].min
        buckets[index][1] = [buckets[index][1], x].max
    }
    
    prev = buckets.first
    max_gap = 0
    buckets.compact.each { |x|
        max_gap = [x[0] - prev[1], max_gap].max
        prev = x
    }
    
    return max_gap
end

puts maximum_gap([1, 2, 3, 4, 5, 6])
puts maximum_gap([1])
puts maximum_gap([1, 1000])
puts maximum_gap([1, 4])
puts maximum_gap([1, 4, 5, 6])
puts maximum_gap([])
