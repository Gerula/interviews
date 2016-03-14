#   https://leetcode.com/problems/house-robber-iii/
#    The thief has found himself a new place for his thievery again.
#    There is only one entrance to this area, called the "root." Besides the root, each house has one and only one parent house.
#    After a tour, the smart thief realized that "all houses in this place forms a binary tree".
#    It will automatically contact the police if two directly-linked houses were broken into on the same night.
#
#    Determine the maximum amount of money the thief can rob tonight without alerting the police. 
#   
#   https://leetcode.com/submissions/detail/56269018/
#
#   Submission Details
#   124 / 124 test cases passed.
#       Status: Accepted
#       Runtime: 120 ms
#           
#           Submitted: 0 minutes ago
class What < Struct.new(:steal, :dont_steal)
end

def rob(root)
    result = process(root)
    [result.steal, result.dont_steal].max
end

def process(root)
    return What.new(0, 0) if root.nil?
    left = process(root.left)
    right = process(root.right)
    What.new(
        root.val + left.dont_steal + right.dont_steal, 
        [left.steal, left.dont_steal].max + [right.steal, right.dont_steal].max)
end
