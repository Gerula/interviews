#   https://leetcode.com/problems/remove-duplicates-from-sorted-list/
#   Given a sorted linked list, delete all duplicates such that each element appear only once. 
#   https://leetcode.com/submissions/detail/55726906/
#
#   Submission Details
#   164 / 164 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 88.00% of rubysubmissions.
def delete_duplicates(head)
    it = head
    while it
        if it.next && it.val == it.next.val
            it.next = it.next.next
        else
            it = it.next
        end
    end
    
    head
end
