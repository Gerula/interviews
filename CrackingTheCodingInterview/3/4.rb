# In the classic problem of the Towers of Hanoi, you have 3 rods and N disks of different sizes which can slide onto any tower. The puzzle starts with disks sorted in ascending order of size from top to bottom (e.g., each disk sits on top of an even larger one). You have the following constraints:
# 
# (A) Only one disk can be moved at a time.
# (B) A disk is slid off the top of one rod onto the next rod.
# (C) A disk can only be placed on top of a larger disk.
# Write a program to move the disks from the first rod to the last using Stacks.

class Stack
    def initialize
        @array = []
    end

    def push(element)
        @array.push(element)
    end 

    def pop
        @array.pop
    end

    def size
        @array.length
    end

    def peek
        @array[-1]
    end
end

class Hanoi
    require "ostruct"

    def initialize(discs)
        @disks = discs
        @stacks = []
        3.times {
            @stacks.push(Stack.new)
        }
        
        @disks.downto(1).each { |disc|
            @stacks[0].push(disc)
        }

        @moves = Stack.new
    end

    def solve_iteratively
        if @disks % 2
            move(0, 1)
        else
            move(0, 2)
        end

        while @stacks[2].size != @disks
            (0..2).each { |x|
                if @stacks[x].size == 0
                    next
                end

                neighbors = [ (x + 1) % 3, (x - 1) % 3]
                neighbors.each { |neighbor|
                    if  ((@stacks[neighbor].size == 0)||(@stacks[x].peek % 2) != (@stacks[neighbor].peek % 2)) &&
                        @moves.peek.from != neighbor &&
                        @moves.peek.to != x
                       
                        move(x, neighbor)
                        puts self.inspect 
                        gets
                        next
                    end
                }
            }
            gets
        end 
    end

    def move(from, to)
        @stacks[to].push(@stacks[from].pop)
        @moves.push(OpenStruct.new(:from => from, :to => to))
    end
end

hanoi = Hanoi.new(10)
puts hanoi.inspect
hanoi.solve_iteratively
