#   https://leetcode.com/problems/merge-k-sorted-lists/
#   Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity. 
#   
#   TLE
def merge_k_lists(lists)
    lists.reduce { |acc, x|
        merge(acc, x)
    }
end

def merge(a, b)
    return nil if a.nil? && b.nil?
    return a if b.nil?
    return b if a.nil?
    if a.val < b.val
        a.next = merge(a.next, b)
        return a
    end
    
    b.next = merge(a, b.next)
    return b
end
