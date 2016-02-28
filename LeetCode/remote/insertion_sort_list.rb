#   https://leetcode.com/problems/insertion-sort-list/
#   Sort a linked list using insertion sort.
#
#   TLE - the OJ is tripping balls
def insertion_sort_list(head)
    dummy = ListNode.new(:marker)
    while head
        insert = dummy
        while insert.next && insert.next.val < head.val
            insert = insert.next
        end
        
        next_head = head.next
        head.next = insert.next
        insert.next = head
        head = next_head
    end
    
    dummy.next
end
