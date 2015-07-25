# https://leetcode.com/submissions/detail/34094541/

def add_two_numbers(l1, l2)
    result = nil
    previous = nil
    remainder = 0
    while l1 || l2
        first = 0
        if l1 
            first = l1.val
            l1 = l1.next
        end
        
        second = 0
        if l2
            second = l2.val
            l2 = l2.next
        end
        
        remainder, mod = (first + second + remainder).divmod(10)
        current = ListNode.new(mod)
        if previous
            previous.next = current
            previous = current
        else
            previous = current
            result = current
        end
    end
    
    if remainder != 0
        current = ListNode.new(remainder)
        previous.next = current
    end
    
    return result
end
