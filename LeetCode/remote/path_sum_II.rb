#   https://leetcode.com/problems/path-sum-ii/
#   https://leetcode.com/submissions/detail/54647069/

def path_sum(root, sum)
    return [] if root.nil?
    return [[root.val]] if sum == root.val && root.left.nil? && root.right.nil?
    (path_sum(root.left, sum - root.val) +
     path_sum(root.right, sum - root.val))
    .map { |x|
        [root.val] + x
    }
end

#   https://leetcode.com/submissions/detail/57269708/
def path_sum(root, sum)
    return [] if root.nil?
    if root.left.nil? && root.right.nil? 
        return root.val == sum ? [[root.val]] : []
    end
    
    (path_sum(root.left, sum - root.val) + 
    path_sum(root.right, sum - root.val)).map { |x|
        [root.val] + x
    }
end
