#   http://www.geeksforgeeks.org/find-all-possible-trees-with-given-inorder-traversal/
#   Given an array that represents Inorder Traversal,
#   find all possible Binary Trees with the given Inorder traversal and print their preorder traversals.

class Node < Struct.new(:val, :left, :right)
    def to_s
        "#{val} #{left.to_s}#{right.to_s}"
    end
end

def gen_trees(array, hash = nil)
    return [nil] if  array.nil? || array.empty?
    hash ||= {}
    !hash[array].nil? ? 
    hash[array] : 
    hash[array] = (0...array.size)
                  .map { |i|
                      gen_trees(array[0...i], hash)
                      .product(gen_trees(array[i + 1..-1], hash))
                      .map { |x, y|
                          Node.new(array[i], x, y)
                      }
                  }
end

puts "#{gen_trees([3, 2])}"
puts "#{gen_trees([4, 5, 7])}"
