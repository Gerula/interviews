# https://leetcode.com/submissions/detail/34105802/

def delete_duplicates(head)
    it = head
    while it
        while it && it.next && it.val == it.next.val
            it.next = it.next.next
        end
        it = it.next unless it.nil?
    end
    
    return head
end
