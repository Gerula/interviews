class Node < Struct.new(:value, :link)
    def to_s
        it = self
        result = ""
        while it
            result << "#{it.value} "
            it = it.link
        end

        return result
    end
end

head = nil
10.downto(1).each{ |x|
    head = Node.new(x, head)
}

puts head

slow = head
fast = head
while fast && fast.link
    slow = slow.link
    fast = fast.link.link
end

first = head
second = slow

while first && second
    first_next = first.link
    second_next = second.link
    first.link = second
    second.link = first_next unless first_next == slow
    first = first_next
    second = second_next
end

puts head
