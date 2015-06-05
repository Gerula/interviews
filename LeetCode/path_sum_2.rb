#  Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
#  For example:
#  Given the below binary tree and sum = 22,
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    def initialize
        @root = from_range(0, 10)
    end

    def from_range(left, right)
        return nil if left > right
        mid = left + (right - left) / 2
        return Node.new(mid,
                        from_range(left, mid - 1),
                        from_range(mid + 1, right))
    end

    def display
        puts @root
        current = @root
        stack = []
        while stack.any? || current
            if current
                stack.push(current)
                current = current.left
            else
                current = stack.pop
                print "#{current.value} "
                current = current.right
            end
        end

        puts
    end

    def get_sums(value)
        results = []
        sum(@root, {}, value, results)
        puts results.inspect
    end

    def sum(current, parents, sum, results)
        sum -= current.value
        if current.left.nil? && current.right.nil? && sum == 0
            it = current
            result = []
            while it
               result << it.value
               it = parents[it]
            end
            results << result
            return
        end
        
        sum(current.left, parents.merge({current.left => current}), sum, results) unless current.left.nil?
        sum(current.right, parents.merge({current.right => current}), sum, results) unless current.right.nil?
    end
end

tree = Tree.new
tree.display
tree.get_sums(14)

