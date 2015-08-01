class List < Struct.new(:val, :link)
end

def palindrome?(list, back)
    return true if list.nil?
    result = palindrome?(list.link, back)
    node = back[0]
    back[0] = node.link
    return result && list.val == node.val
end


head = nil
0.upto(3).each { |i| head = List.new(i, head) }
puts head.inspect
puts palindrome?(head, [head])
3.downto(0).each { |i| head = List.new(i, head) }
puts head.inspect
puts palindrome?(head, [head])

