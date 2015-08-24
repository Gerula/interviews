# @param {Integer[]} nums
# @return {Integer}
def missing_number(nums)
    return nums.size * (nums.size + 1)/2 - nums.reduce(:+)
end
