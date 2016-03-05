#   https://leetcode.com/problems/sort-list/
#
#   Sort a linked list in O(n log n) time using constant space complexity.

#   
#   Submission Details
#   15 / 15 test cases passed.
#       Status: Accepted
#       Runtime: 192 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53251589/

# Definition for singly-linked list.
# class ListNode
#     attr_accessor :val, :next
#     def initialize(val)
#         @val = val
#         @next = nil
#     end
# end

# @param {ListNode} head
# @return {ListNode}
def sort_list(head)
    return head if head.nil? || head.next.nil?
    pivot = head.val
    smaller = ListNode.new(-1)
    larger = ListNode.new(-1)
    equal = ListNode.new(-1)
    smaller_end = smaller
    larger_end = larger
    equal_end = equal
    while !head.nil?
        if head.val == pivot
            equal_end.next = head;
            equal_end = equal_end.next
        elsif head.val < pivot
            smaller_end.next = head
            smaller_end = smaller_end.next
        else
            larger_end.next = head
            larger_end = larger_end.next
        end
        
        head = head.next
    end
    
    smaller_end.next = nil
    equal_end.next = nil
    larger_end.next = nil
    
    smaller.next = sort_list(smaller.next)
    larger.next = sort_list(larger.next)
    
    it = smaller
    while !it.next.nil?
        it = it.next
    end
    
    it.next = equal.next;
    while !it.next.nil?
        it = it.next
    end
    
    it.next = larger.next
    return smaller.next
end

#   https://leetcode.com/submissions/detail/55374749/
#
#   Submission Details
#   15 / 15 test cases passed.
#       Status: Accepted
#       Runtime: 320 ms
#           
#           Submitted: 0 minutes ago
def sort_list(head)
    return head if head.nil? || head.next.nil?
    half = head
    finish = head.next
    while finish && finish.next
        half = half.next
        finish = finish.next.next
    end
    
    mid = half.next
    half.next = nil
    return merge(sort_list(head), sort_list(mid))
end

def merge(a, b)
    return nil if a.nil? && b.nil?
    return a if b.nil?
    return b if a.nil?
    if a.val < b.val
        a.next = merge(a.next, b)
        return a
    end
    
    b.next = merge(a, b.next)
    return b
end
