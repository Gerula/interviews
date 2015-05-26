#  Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors. 
#

class Node < Struct.new(:label, :neighbors)
    def inspect
        "#{label} #{neighbors.map{|x| x.label}}"
    end
end

nodes = (1..5).map { |x|
    Node.new(x, [])
}

nodes.each { |x|
    Random.rand(1..nodes.size-1 / 2).times {
        x.neighbors << nodes[Random.rand(1..nodes.size-1)]
    }
}

require 'set'

def bfs_string(x)
    queue = [x]
    visited = Set.new
    visited.add(x)
    result = ""
    while queue.any?
        current = queue.shift
        result += "#{current.label} "
        current.neighbors.each {|x|
            unless visited.include?(x)
                visited.add(x)
                queue.push(x)
            end
        }
    end

    return result
end

puts nodes.inspect
puts bfs_string(nodes[0])
