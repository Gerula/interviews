require 'test/unit'
extend Test::Unit::Assertions

# Definition for singly-linked list.
#
# https://leetcode.com/submissions/detail/38171801/
#
# 55 / 55 test cases passed.
#   Status: Accepted
#   Runtime: 68 ms
#       
#       Submitted: 0 minutes ago
# 
#   You are here!
#   Your runtime beats 94.12% of ruby coders.
#
class ListNode
    attr_accessor :val, :next
    
    def initialize(val)
         @val = val
         @next = nil
    end

    def to_s
        return "#{@val} #{@next.nil? ? "" : @next.to_s}"
    end
end

def swap_pairs(head)
    pre = first = ListNode.new(-1)
    pre.next = head
    while pre.next && pre.next.next
        a = pre.next
        b = pre.next.next
        pre.next = b
        a.next = b.next
        b.next = a
        pre = a
    end

    return first.next
end

head = nil
4.downto(1).each { |i|
    new_node = ListNode.new(i)
    new_node.next = head
    head = new_node
}

assert_equal("2 1 4 3 ", swap_pairs(head).to_s)
