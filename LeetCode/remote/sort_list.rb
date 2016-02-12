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
