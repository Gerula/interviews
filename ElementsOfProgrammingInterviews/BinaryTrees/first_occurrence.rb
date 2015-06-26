class Node < Struct.new(:value, :id, :left, :right)
end

node = Node.new(108, :A,
                Node.new(108, :B,
                         Node.new(-10, :C,
                                  Node.new(-14, :D,
                                           nil, nil),
                                  Node.new(2, :E,
                                           nil, nil)),
                         Node.new(108, :F,
                                  nil, nil)),
                Node.new(285, :G,
                         Node.new(243, :H,
                                  nil, nil),
                         Node.new(285, :I,
                                  nil,
                                  Node.new(401, :J,
                                           nil, nil))))

def inorder(root)
    unless root.nil?
        inorder(root.left)
        print "#{root.value}:#{root.id} "
        inorder(root.right)
    end
end

inorder(node)
puts

# O(N)
def inorder_search(root, value, found)
    unless root.nil?
        inorder_search(root.left, value, found)
        found[0] = root if value == root.value && found[0].nil?
        inorder_search(root.right, value, found)
    end
end

[[108, :B], [285, :G], [143, :nil]].each { |x|
    found = [nil]
    inorder_search(node, x.first, found)
    puts "#{x.inspect} - #{found.first.nil?? :nil : found.first.id}"
}
