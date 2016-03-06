#   https://leetcode.com/problems/dungeon-game/
#   https://leetcode.com/submissions/detail/55474455/
#
#   Submission Details
#   44 / 44 test cases passed.
#       Status: Accepted
#       Runtime: 340 ms
#           
#           Submitted: 0 minutes ago
def calculate_minimum_hp(dungeon)
    return 1 if dungeon.empty?
    n = dungeon.size
    m = dungeon[0].size
    max_int = 2 ** (0.size * 8 - 1)
    dp = Array.new(n + 1) {
        Array.new(m + 1)
    }
    
    dp[n][m - 1], dp[n - 1][m] = 1, 1
    (n - 1).downto(0).each { |i|
        (m - 1).downto(0).each { |j|
            energy = [dp[i][j + 1] || max_int, dp[i + 1][j] || max_int].min - dungeon[i][j]
            puts "#{energy}"
            dp[i][j] = energy > 0 ? energy : 1
        }
    }
    
    dp[0][0]
end
