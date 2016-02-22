#   https://leetcode.com/problems/palindrome-linked-list/
#
#   Given a singly linked list, determine if it is a palindrome.
#
#   Follow up:
#   Could you do it in O(n) time and O(1) space?
#   
#   https://leetcode.com/submissions/detail/54138312/
#
#   Submission Details
#   21 / 21 test cases passed.
#       Status: Accepted
#       Runtime: 116 ms
#           
#           Submitted: 0 minutes ago

def is_palindrome(head)
    return true if head.nil?
    
    mid = head
    list_end = head.next
    while !mid.nil? && !list_end.nil? && !list_end.next.nil?
        mid = mid.next
        list_end = list_end.next.next
    end

    second = mid.next
    mid.next = nil
    prev = nil
    while !second.nil?
        next_node = second.next
        second.next = prev
        prev = second
        second = next_node
    end
    
    second = prev
    first = head
    
    while !second.nil? && !first.nil?
        return false if second.val != first.val
        second = second.next
        first = first.next
    end
    
    return true
end
