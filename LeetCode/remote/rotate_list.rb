# 
# Submission Details
# 230 / 230 test cases passed.
#   Status: Accepted
#   Runtime: 100 ms
#       
#       Submitted: 0 minutes ago
#
#       https://leetcode.com/submissions/detail/39238024/

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

head = nil
5.downto(1).each { |i|
    new = ListNode.new(i)
    new.next = head
    head = new
}

puts head

def rotate_right(head, k)
    return head if head.nil?
    it = head
    count = 0
    while it && it.next
        count += 1
        it = it.next
    end

    count += 1

    prev = it
    it.next = head

    (count - k % count).times { 
        head = head.next
        prev = prev.next
    }

    prev.next = nil
    return head
end

puts rotate_right(head, 2)
puts rotate_right(ListNode.new(1), 4)
