# https://leetcode.com/submissions/detail/34137839/

# @param {TreeNode} root
# @return {Void} Do not return anything, modify root in-place instead.
def flatten(root)
    return  if root.nil?
    
    left = root.left
    right = root.right
    
    root.left = nil
    root.right = nil
    flatten(left)
    flatten(right)
    if left
       root.right = left
    end
    it = root
    while it.right
        it = it.right
    end
    
    it.right = right
    return
end
