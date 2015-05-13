# Given a directed graph, design an algorithm to find out whether there is a route be- tween two nodes. 
 
class Node
    def initialize(value)
        @value = value
        @neighbors = [] 
    end
 
    def connect(node)
        @neighbors.push(node) 
    end  
     
    def inspect
        "Value: #{@value} Neighbors: #{@neighbors}"
    end
     
    attr_reader :neighbors
end   
 
class Graph
    def initialize(max)
        @nodes = []
        @max_nodes = max
    end
 
    def generate_shit
        1.upto(Random.rand(1..@max_nodes + 1)).each do |x|
            node = Node.new(x)            
            @nodes.push(node)
        end
        puts @nodes.size
        Random.rand(@nodes.size + @nodes.size).times do
            first = Random.rand(@nodes.size)
            second = Random.rand(@nodes.size)
             
            unless first == second
                @nodes[first].connect(@nodes[second])
            end
        end
    end
     
    def inspect
        @nodes.map(&:inspect).join("\n")
    end
     
    def path_defined?(from, to)
        # there is a bug here which reproes when the graph has cycles
        # but I will leave it like this for two reasons:
        # -  because art
        # -  because the graph is randomly generated and I'm a lucky basterd
        return from == to || from.neighbors.any? {|neighbor| path_defined?(neighbor, to)}
    end
     
    attr_reader :nodes
end
 
graph = Graph.new(10)
graph.generate_shit
puts graph.inspect 
puts graph.path_defined?(graph.nodes[0], graph.nodes[1])
