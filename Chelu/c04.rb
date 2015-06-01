# Topological sort
#

class Node < Struct.new(:value, :out_neighbors, :in_neighbors, :in_degree)
    def inspect
        "#{value} - Deg - #{in_degree}"
    end
end

nodes = []
1.upto(6).each { |i|
    nodes << Node.new(i, [], [], 0)
}

def connect(a, b)
    a.out_neighbors << b
    b.in_neighbors << a
    b.in_degree += 1
end

connect(nodes[0], nodes[1])
connect(nodes[0], nodes[2])
connect(nodes[1], nodes[2])
connect(nodes[2], nodes[3])
connect(nodes[3], nodes[4])
connect(nodes[2], nodes[4])
connect(nodes[4], nodes[5])

queue = nodes.select { |x| x.in_degree == 0}
result = []

while queue.any?
    current = queue.shift
    result << current
    current.out_neighbors.each {|x|
        x.in_degree -= 1
        if x.in_degree == 0
            queue << x
        end
    }
end

puts result.inspect

result.clear

puts result.inspect

visited = []

nodes.each {|x|
    next if visited.include?(x) 

    stack = [x]
    
    while stack.any?
        current = stack.pop
        unless visited.include?(current)
            result << current
            visited << current
            current.out_neighbors.each {|x| stack.push(x)} 
        end
    end
}

puts result.inspect
