# https://leetcode.com/submissions/detail/34107740/

# @param {ListNode} head
# @return {ListNode}
def delete_duplicates(head)
    return head if head.nil? || head.next.nil?
    new_head = nil
    pre = nil
    it = head
    while it
        flag = false
        while it.next && it.next.val == it.val
            flag = true
            it = it.next
        end
        
        unless flag
            new_node = ListNode.new(it.val)
            if pre == nil
                pre = new_node
                new_head = new_node
            else
                pre.next = new_node
                pre = pre.next
            end
        end
        
        it = it.next
    end
    
    return new_head
end
