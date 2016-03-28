#   https://leetcode.com/problems/partition-list/
#   Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
#
#   You should preserve the original relative order of the nodes in each of the two partitions. 
#   https://leetcode.com/submissions/detail/57523272/
#
#   Submission Details
#   166 / 166 test cases passed.
#       Status: Accepted
#       Runtime: 83 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.

def partition(head, x)
    less = ListNode.new(:less)
    less_last = less
    more = ListNode.new(:more)
    more_last = more
    while head
        next_head = head.next
        head.next = nil
        if head.val < x
            less_last.next = head
            less_last = head
        else
            more_last.next = head
            more_last = head
        end
        
        head = next_head
    end
    
    less_last.next = more.next
    return less.next
end
