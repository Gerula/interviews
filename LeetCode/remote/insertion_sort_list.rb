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

# Clearly tripping balls. This is quicksort and still TLE

def insertion_sort_list(head)
    return head if head.nil? || head.next.nil?
    lower = ListNode.new(:marker)
    equal = ListNode.new(:marker)
    larger = ListNode.new(:marker)
    lower_end = lower
    equal_end = equal
    larger_end = larger
    pivot = head
    it = head
    while it
        next_it = it.next
        it.next = nil
        if it.val < pivot.val
            lower_end.next = it
            lower_end = lower_end.next
        elsif it.val > pivot.val
            larger_end.next = it
            larger_end = larger_end.next
        else
            equal_end.next = it
            equal_end = equal_end.next
        end
        
        it = next_it
    end
    
    lower.next = insertion_sort_list(lower.next)
    larger.next = insertion_sort_list(larger.next)
    it = lower
    while it && it.next
        it = it.next
    end
    
    it.next = equal.next
    equal_end.next = larger.next
    return lower.next
end
