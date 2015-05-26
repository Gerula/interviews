#  Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors. 
#

class Node < Struct.new(:label, :neighbors)
    attr_accessor :link

    def inspect
        str_link = link.nil? ? "x" : link.label
        "#{label} link:#{str_link} #{neighbors.map{|x| x.label}}"
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

def bfs(x, block)
    queue = [x]
    visited = Set.new
    visited.add(x)
    puts "--- Linking to new nodes ---"
    while queue.any?
        current = queue.shift
        block.call(current, visited)
        current.neighbors.each {|x|
            if !visited.include?(x)
                visited.add(x)
                queue.push(x)
            end
        }
    end
end

def clone(x)
    result = x
    bfs(x, -> (x, visited) { x.link = Node.new(x.label)})
    bfs(x, -> (x, visited) { x.neighbors.each {|y|
        if visited.include?(y)
            y = y.link
        end
    }})
    bfs(x, -> (x,visited) { x = x.link })

    x
end

puts nodes.inspect
puts bfs_string(nodes[0])
puts bfs_string(clone(nodes[0]))
puts nodes.inspect
