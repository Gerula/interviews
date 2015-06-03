# The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
#

def print_queens(result, n)
    puts "-" * n
    result.each { |x|
        puts "." * (x) + "0" + "." * (n - 1 - x)
    }
end

def conflict?(position, result)
    return true if result.include?(position)
    diagonal_right = position
    diagonal_left = position
    offset = 0
    (result.size-1).downto(0).each { |i|
        diagonal_right += 1
        diagonal_left -= 1
        return true if diagonal_left == result[i] || diagonal_right == result[i]
    }

    return false
end

def queens(result, n)
    if result.size == n
        print_queens(result, n)
        return
    end
    
    0.upto(n-1).each { |i|
        if !(result.any? && conflict?(i, result))
            result.push(i)
            queens(result, n)
            result.pop
        end
    }
end

queens([], 4)
