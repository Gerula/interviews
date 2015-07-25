# https://leetcode.com/submissions/detail/34085212/

def path_sum(root, sum)
    result = []
    path(root, result, sum, [root.val]) unless root.nil?
    return result
end

def path(node, result, sum, partial)
    return if node.nil?
    if sum - node.val == 0 && node.left.nil? && node.right.nil?
        result << partial.dup
        return
    end

    path(node.left, result, sum - node.val, partial + [node.left.val]) unless node.left.nil?
    path(node.right, result, sum - node.val, partial + [node.right.val]) unless node.right.nil?
end
