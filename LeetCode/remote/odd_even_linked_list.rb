#   https://leetcode.com/problems/odd-even-linked-list/
#
#   Given a singly linked list, group all odd nodes together followed by the even nodes.
#   Please note here we are talking about the node number and not the value in the nodes.
#
#   You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.
#   https://leetcode.com/submissions/detail/53960532/
#
#   Submission Details
#   70 / 70 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago

def odd_even_list(head)
    odd = ListNode.new(-1)
    even = ListNode.new(-1)
    oddLast = odd
    evenLast = even
    it = head
    while !it.nil?
        oddLast.next, evenLast.next = it, it.next
        oddLast, evenLast = oddLast.next, evenLast.next
        it = it.next.nil? ? nil : it.next.next
    end
    oddLast.next = even.next
    return odd.next
end
