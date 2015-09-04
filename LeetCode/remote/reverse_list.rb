# Reverse a singly linked list.

class ListNode
    attr_accessor :val, :next
    def initialize(val)
        @val = val
        @next = nil
    end

    def to_s
        "#{@val} #{@next.nil? ? "" : @next.to_s}"
    end
end

# https://leetcode.com/submissions/detail/38707904/
# 
# Submission Details
# 27 / 27 test cases passed.
#   Status: Accepted
#   Runtime: 96 ms
#       
#       Submitted: 1 minute ago
#
#
def reverse_list(head)
    prev = nil
    while head
        next_ = head.next
        head.next = prev
        prev = head
        head = next_
    end

    return prev
end

# https://leetcode.com/submissions/detail/38709409/
#
# Submission Details
# 27 / 27 test cases passed.
#   Status: Accepted
#   Runtime: 80 ms
#       
#       Submitted: 0 minutes ago
#
def reverse(head)
    return head if head.nil? || head.next.nil?
    next_node = reverse(head.next)
    head.next.next = head
    head.next = nil
    return next_node
end

head = nil
5.downto(0).each { |i|
    prev = head
    head = ListNode.new(i)
    head.next = prev
}

puts head.to_s
head = reverse_list(head)
puts head.to_s
head = reverse(head)
puts head.to_s
