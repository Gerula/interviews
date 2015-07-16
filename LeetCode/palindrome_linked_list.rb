class Node < Struct.new(:value, :link)
    def to_s
        return "#{self.value} #{self.link.nil? ? nil : self.link.to_s}"
    end
end

def palindrome?(left, right) 
    if right.nil?
        return true
    end

    if !palindrome?(left, right.link)
        return false
    end

    result = left[0].value == right.value
    left[0] = left[0].link
    return result
end

root = nil
1.upto(5).each { |x|
    root = Node.new(x, root)
} 

5.downto(1).each { |x|
    root = Node.new(x, root)
}

puts root
puts palindrome?([root], root)
root = Node.new(2, root)
puts palindrome?([root], root)

