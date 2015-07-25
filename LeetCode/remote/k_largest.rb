# https://leetcode.com/submissions/detail/34088459/

def kth_smallest(root, k)
    result = []
    smallest(root, [k], result)
    return result[0]
end

def smallest(node, k, result)
    return if node.nil?
    smallest(node.left, k, result)
    k[0] -= 1
    result[0] = node.val if k[0] ==0
    smallest(node.right, k, result)
end
