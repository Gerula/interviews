# http://www.careercup.com/question?id=5143327210995712
#
# Alledgedly a phone interview question. Fucking hell...

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def cross?
        # Quit bitching
        

    end
end

class TestData < Struct.new(:array, :result, :instructions)
    def initialize
        lines = Random.rand(5..30)
        columns = Random.rand(5..30)
        position = [lines / 2, columns / 2]
        self.array = Array.new(lines) {
            Array.new(columns) {
                0
            }
        }

        self.instructions = []

        self.result = true
        directions = [[-1, 0], [0, -1], [1, 0], [0, 1]].cycle
        self.array[position.first][position.last] = 1
        Random.rand(3..10).times {
            direction = directions.next
            max_offset = case direction
                            when [-1, 0] then position[0] - 1
                            when [0, -1] then position[1] - 1
                            when [1, 0] then lines - position[0]
                            when [0, 1] then columns - position[1]
                        end
            offset = Random.rand(0..max_offset)
            self.instructions << offset
            offset.times {
                position[0], position[1] = position[0] + direction[0], position[1] + direction[1]
                self.array[position.first][position.last] += 1
                self.result &= self.array[position.first][position.last] == 1
            }
        }
    end

    def to_s
        puts self.array.map{ |x| x.inspect }
        puts self.instructions.inspect
        puts "#{self.result}"
    end
end

5.times {
    testdata = TestData.new
    puts testdata
}
