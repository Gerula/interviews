#   https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/
#   Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
#   https://leetcode.com/submissions/detail/55117463/
#
#   Submission Details
#   32 / 32 test cases passed.
#       Status: Accepted
#       Runtime: 740 ms
#           
#           Submitted: 0 minutes ago
#
#   What a fucking struggle
def sorted_list_to_bst(head)
    return nil if head.nil?
    return TreeNode.new(head.val) if head.next.nil?
    half = head
    prev = head
    finish = head.next
    while finish && finish.next
        prev = half
        half = half.next
        finish = finish.next.next
    end
    
    mid = prev.next
    prev.next = nil
    result = TreeNode.new(mid.val)
    result.left = sorted_list_to_bst(head)
    result.right = sorted_list_to_bst(mid.next)
    result
end

#   Better version. And I learned a new trick! You don't need to break the list actually..
#   https://leetcode.com/submissions/detail/55157641/
#
#   Submission Details
#   32 / 32 test cases passed.
#       Status: Accepted
#       Runtime: 781 ms
#           
#           Submitted: 0 minutes ago
def sorted_list_to_bst(head)
    return sorted_to_bst(head, nil)
end

def sorted_to_bst(low, high)
    return nil if low == high
    return TreeNode.new(low.val) if low.next == high
    half = low
    finish = low.next
    while finish != high && finish.next != high
        half = half.next
        finish = finish.next.next
    end
    
    result = TreeNode.new(half.val)
    result.left = sorted_to_bst(low, half)
    result.right = sorted_to_bst(half.next, high)
    result
end
