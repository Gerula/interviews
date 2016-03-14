#   http://lcoj.tk/problems/find-all-sum-solution-for-positive-number-lalayangguang-draft/
#    Give a positive number N, find all possible positive numbers can be sum equals N.
#
#    for example
#
#    N = 4 , there are {[1,3],[3,1],[2,2],[1,1,1,1],[1,1,2],[1,2,1],[2,1,1]} , then return 7.
#
#    N = 2, solutions are {[1,1]}, return 1
#
#    assume result will not overflow
#
#    for N = 4 , [1,3] and [3,1] are two different solutions
#

require 'test/unit'
extend Test::Unit::Assertions

def count_sum_solution(target)
    target < 2 ? 0 : (1...target)
                      .map { |x| 1 + count_sum_solution(target - x) }
                      .reduce(:+)
end

def count_sum_solution_dp(target)
    dp = [0, 0]
    (2..target).each { |i|
        dp[i] = 0
        (1...i).each { |j|
            dp[i] += 1 + dp[i - j]
        }
    }

    dp[target]
end

assert_same(0, count_sum_solution_dp(1), "1 dp")
assert_same(1, count_sum_solution_dp(2), "2 dp")
assert_same(7, count_sum_solution_dp(4), "4 dp")
assert_same(0, count_sum_solution(1), "1")
assert_same(1, count_sum_solution(2), "2")
assert_same(7, count_sum_solution(4), "4")
