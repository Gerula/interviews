class Node < Struct.new(:value, :left, :right)
    def print_vertically
        levels = {}
        print_v(self, 0, levels)
        puts levels.keys.sort.map { |x| levels[x] }.inspect
    end

    def print_v(node, offset, levels)
        unless node.nil?
            print_v(node.left, offset - 1, levels)
            print_v(node.right, offset + 1, levels)
            levels[offset] ||= []
            levels[offset] << node.value
        end
    end
end

root = Node.new(1,
                Node.new(2,
                         Node.new(4),
                         Node.new(5)),
                Node.new(3,
                         Node.new(6,
                                  nil,
                                  Node.new(8)),
                         Node.new(7,
                                  nil,
                                  Node.new(9))))

root.print_vertically
