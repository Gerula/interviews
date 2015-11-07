# Print a tree in zigzag
#

class Node < Struct.new(:val, :left, :right)
    def print
        zig_zag(0)
    end

    def inorder
        return "#{left.nil? ? "" : left.inorder}#{val} #{right.nil? ? "" : right.inorder}"
    end

    def zig_zag(level)
        l = level % 2 == 1 ? left : right
        r = l == left ? right : left

        "#{val} #{l.nil? ? "" : l.zig_zag(level + 1)}#{r.nil? ? "" : r.zig_zag(level + 1)}"
    end

    def levels(level, hash)
        if hash[level].nil?
            hash[level] = [val] 
        else
            hash[level] = level % 2 == 0 ? hash[level].push(val) : hash[level].unshift(val)
        end

        left.levels(level + 1, hash) if !left.nil?
        right.levels(level + 1, hash) if !right.nil?
    end
end

def build_tree(low, high)
    return nil if low > high
    mid = low + (high - low) / 2
    return Node.new(mid,
                    build_tree(low, mid - 1),
                    build_tree(mid + 1, high))
end

node = build_tree(1, 15)
puts node.inorder
puts
puts node.print

hash = {}
node.levels(0, hash)
puts hash.keys.sort.inject([]) { |acc, x|
    [acc, hash[x]].flatten 
}.inspect

