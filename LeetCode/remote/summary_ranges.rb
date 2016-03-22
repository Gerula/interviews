#   https://leetcode.com/problems/summary-ranges/
#    Given a sorted integer array without duplicates, return the summary of its ranges.
#
#    For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"].
#   https://leetcode.com/submissions/detail/56997442/
#
#   Submission Details
#   27 / 27 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
def summary_ranges(nums)
    nums.reduce([]) { |acc, x|
        if acc.empty? || acc.last.last + 1 != x
            acc << [x, x]
        else
            acc << [acc.pop.first, x]
        end
    }.map { |x|
        x.first == x.last ? x.first.to_s : "#{x.first}->#{x.last}"
    }
end
