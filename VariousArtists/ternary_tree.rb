class Node < Struct.new(:symbol, :word_end, :left, :center, :right)
end

class Tree
   def initialize
       @root = nil
   end

   def add(s)
       @root = insert(s, 0, @root)
   end

   def insert(s, index, current)
       node = current
       if node == nil
           node = Node.new(s[index], false)
       end

       if s[index] < node.symbol
           node.left = insert(s, index, current.left)
       elsif s[index] > node.symbol
           node.right = insert(s, index, current.left)
       else
           if index + 1 == s.size
               node.word_end = true
           else
               node.center = insert(s, index + 1, node.center)
           end
       end

       return node
   end
end

t = Tree.new
t.add("banana")
t.add("banona")
puts t.inspect
