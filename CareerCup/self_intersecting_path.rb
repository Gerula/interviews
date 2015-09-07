# http://www.careercup.com/question?id=5143327210995712
#
# Alledgedly a phone interview question. Fucking hell...

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def cross?
        for i in 3...self.size
            prev = i > 4 ? self[i - 4] : 0
            return true if self[i] + prev >= self[i - 2] && self[i - 1] <= self[i - 3]
        end

        return false
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

        self.result = false
        directions = [[-1, 0], [0, -1], [1, 0], [0, 1]].cycle
        self.array[position.first][position.last] = 5
        Random.rand(3..10).times {
            direction = directions.next
            max_offset = case direction
                            when [-1, 0] then position[0]
                            when [0, -1] then position[1]
                            when [1, 0] then lines - position[0]
                            when [0, 1] then columns - position[1]
                        end
            offset = Random.rand(1...max_offset)
            self.instructions << offset
            offset.times {
                position[0], position[1] = position[0] + direction[0], position[1] + direction[1]
                self.array[position.first][position.last] += 1
                self.result = self.array[position.first][position.last] != 1
                return if self.result
            }
        }
    end

    def to_s
        puts self.array.map{ |x| x.inspect }
        puts self.instructions.inspect
        puts "#{self.result}"
    end
end

Random.rand(5..20).times {
    testdata = TestData.new
    puts testdata
    assert_equal(testdata.result, testdata.instructions.cross?)
}
