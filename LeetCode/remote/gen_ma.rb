# https://leetcode.com/submissions/detail/33922895/

# @param {Integer} n
# @return {Integer[][]}
def generate_matrix(n)
    result = Array.new(n) { |x|
        Array.new(n) { |y|
            0
        }
    }
    return [] if n == 0
    right = {}
    right[[0, 1]] = [1, 0]
    right[[1, 0]] = [0, -1]
    right[[0, -1]] = [-1, 0]
    right[[-1, 0]] = [0, 1]
    
    line = 0
    column = 0
    direction = [0, 1]
    1.upto(n ** 2).each { |x|
        result[line][column] = x
        if (x != n ** 2)
            while  (!(line + direction[0]).between?(0, n - 1) || !(column + direction[1]).between?(0, n - 1) || result[line + direction[0]][column + direction[1]] != 0)
                direction = right[direction]
            end
            line, column = line + direction[0], column + direction[1]
        end
    }
    
    return result
end

puts generate_matrix(3).inspect
