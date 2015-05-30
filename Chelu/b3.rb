#  Given a maze represented by a grid and a robot. Write code that helps the robot travel from a starting point to the end. The robot has the following API:
#
#  Interface robot
#  {
#  CanGo() //checks to see if it can travel in the direction it is facing.
#  TurnRight() // changes direction
#  IsAtFinish() //returns true if standing at the end of the maze.
#  Go() //moves 1 step in the direction it is facing.
#  }
#
#  r - starting point.
#  X - blocked area.
#  f - finish. 

class Robot
    def initialize(maze, position)
        @position = position
        @direction = [-1, 0]
        @maze = maze
        @directions = [[-1, -1], [-1, 0], [-1, 1], [0, 1], [1, 1], [1, 0], [1, -1], [0, -1]]
    end

    def escape!
        stack = [@position]
        visited = [@position]
        while !stack.empty?
            @position = stack.pop
            if is_at_finish?
                puts "Finished!"
                puts visited.inspect
                return
            end

            (@directions.size).times {
                if can_go?(visited)
                    go
                    stack.push(@position)
                    visited << @position
                end
                turn_right
            }
        end
    end

    def new_position
        return [@position[0] + @direction[0], @position[1] + @direction[1]]
    end

    def can_go?(visited)
        new_pos = new_position
        return new_pos[0].between?(0, @maze.size - 1) &&
               new_pos[1].between?(0, @maze[0].size - 1) &&
               @maze[new_pos[0]][new_pos[1]] != "x" &&
               !visited.include?(new_pos)
    end

    def go
        @position = new_position
    end

    def is_at_finish?
        return @maze[@position[0]][@position[1]] == "f"
    end

    def turn_right
        @direction = @directions[(@directions.find_index(@direction) + 1) % @directions.size]        
    end
end

maze = [["x", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x"],
        ["x", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x"],
        ["x", " ", "x", "x", "x", "x", " ", "x", "x", "x", "x"],
        ["x", " ", "x", "x", "x", "x", " ", "x", "x", "x", "x"],
        ["x", " ", "x", "x", "x", "x", " ", "x", "x", "x", "x"],
        ["x", " ", "x", "x", "x", "x", " ", "x", "x", "x", "x"],
        ["x", " ", "x", "x", "x", " ", " ", "x", "x", "x", "x"],
        ["x", " ", "x", "x", "x", " ", "x", "x", "x", "x", "x"],
        ["x", " " ,"x", "x", "x", " ", " ", " ", " ", " ", "f"],
        ["x", "r", "x", "x", "x", "x", "x", "x", "x", "x", "x"],
        ["x", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x"]]

robot = Robot.new(maze, [9, 1])
robot.escape!
puts robot.inspect

