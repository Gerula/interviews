#   https://leetcode.com/problems/reverse-nodes-in-k-group/
#    Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
#
#    If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
#
#    You may not alter the values in the nodes, only nodes itself may be changed.
#
#    Only constant memory is allowed.
#
#    Yay coding olympics
#
#    https://leetcode.com/submissions/detail/55073488/
#
#    Submission Details
#    81 / 81 test cases passed.
#       Status: Accepted
#       Runtime: 99 ms
#           
#           Submitted: 0 minutes ago
# Definition for singly-linked list.
# class ListNode
#     attr_accessor :val, :next
#     def initialize(val)
#         @val = val
#         @next = nil
#     end
# end

# @param {ListNode} head
# @param {Integer} k
# @return {ListNode}
def reverse_k_group(head, k)
    last = nil
    it = head
    while it
        start = it
        finish = it
        count = 0
        while count < k && it
            finish = it
            it = it.next
            count += 1
        end
        
        break if k != count
        finish.next = nil
        if last
            last.next = reverse(start)
        else
            head = reverse(start)
        end
        
        start.next = it
        last = start
    end
    
    head
end

def reverse(head)
    prev = nil
    it = head
    while it
        right = it.next
        it.next = prev
        prev = it
        it = right
    end
    
    prev
end

#   https://leetcode.com/submissions/detail/55765538/
#
#   Submission Details
#   81 / 81 test cases passed.
#       Status: Accepted
#       Runtime: 100 ms
#           
#           Submitted: 0 minutes ago
def reverse_k_group(head, k)
    count = 0
    it = head
    while it && count < k
        count += 1
        it = it.next
    end
    
    if count == k
        it = reverse_k_group(it, k)
        
        while count > 0
            count -= 1
            tmp = head.next
            head.next = it
            it = head
            head = tmp
        end
        
        head = it
    end
    
    head
end
