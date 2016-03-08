#   https://leetcode.com/problems/subsets/
#    Given a set of distinct integers, nums, return all possible subsets. 
#
#    This is broken. I need to fix the flattening and the array construction - which is a programming puzzle on it's own.
def subsets(nums)
    return [[]] if nums.empty?
    return [[],[nums.first]] if nums.size == 1
    [[], (0...nums.size).map {|x|
        [[nums[x]], subsets(nums[x + 1..-1]).map { |y| [nums[x]] + y }]
    }.flatten]
end
