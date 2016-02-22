#   https://leetcode.com/problems/n-queens/
#
#   The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
#
#   Given an integer n, return all distinct solutions to the n-queens puzzle.
#   https://leetcode.com/submissions/detail/54143634/
#
#   Submission Details
#   9 / 9 test cases passed.
#       Status: Accepted
#       Runtime: 196 ms
#           
#           Submitted: 0 minutes ago

def solve_n_queens(n)
   result = []
   n_queens(0, n, [], result)
   return result
end

def n_queens(current, n, partial, result)
    if current == n
        result << partial.map { |x| "." * x + "Q" + "." * (n - x - 1) }
        return
    end

    (0...n)
    .select { |x| valid(partial, x) }
    .each { |x|
        partial.push(x)
        n_queens(current + 1, n, partial, result)
        partial.pop()
    }
end

def valid(partial, pos)
    (0...partial.size).find { |i| partial[i] == pos || (pos - partial[i]).abs == (partial.size - i).abs }.nil?
end
