#   https://leetcode.com/problems/longest-increasing-subsequence/
#   Given an unsorted array of integers, find the length of longest increasing subsequence. 
#   https://leetcode.com/submissions/detail/54959933/
def length_of_lis(nums)
    len = []
    (0...nums.size).map { |i|
        len[i] = (0...i)
                  .select { |j| nums[j] < nums[i] }
                  .map { |j| len[j] + 1 }.max || 1
    }.max || 0
end
