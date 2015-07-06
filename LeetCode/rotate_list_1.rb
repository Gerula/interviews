class Node < Struct.new(:value, :link) 
    def to_i
        s = "#{self.value} "
        t = self.link.nil? ? "" : self.link.to_i
        return s + t
    end
end

head = nil
7.downto(1).each { |i|
    head = Node.new(i, head)
}

k = 4
fast = head
(k - 1).times {
    fast = fast.link
}

last = nil
new_root = head
while fast.link
    last = new_root
    new_root = new_root.link
    fast = fast.link
end

fast.link = head
last.link = nil
head = new_root

puts head.to_i
