# https://leetcode.com/submissions/detail/34086636/

def has_path_sum(root, sum)
    return false if root.nil?
    
    if root.left.nil? && root.right.nil?
        return sum - root.val == 0
    end
    
    return has_path_sum(root.left, sum - root.val) || has_path_sum(root.right, sum - root.val)
end
