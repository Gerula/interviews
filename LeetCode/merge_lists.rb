# https://leetcode.com/submissions/detail/36114270/

def merge_two_lists(l1, l2)
    return l2 if l1.nil?
    return l1 if l2.nil?
    if l1.val < l2.val
        l1.next = merge_two_lists(l1.next, l2)
        return l1
    else
        l2.next = merge_two_lists(l1, l2.next)
        return l2
    end
end
