#   https://leetcode.com/problems/combination-sum-ii/
#
#    Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.
#
#    Each number in C may only be used once in the combination.
#    
#    https://leetcode.com/submissions/detail/54457255/
#   
#   Submission Details
#   172 / 172 test cases passed.
#       Status: Accepted
#       Runtime: 172 ms
#           
#           Submitted: 0 minutes ago

def combination_sum2(candidates, target)
    combination_sum(candidates.sort, target)
end

def combination_sum(candidates, target)
    return nil if target < 0
    result = []
    (0...candidates.size).each { |i|
        next if i > 0 && candidates[i] == candidates[i - 1]
        candidate = candidates[i]
        if candidate == target
            result << [candidate]
        else
            right = combination_sum(candidates[i + 1..-1], target - candidate)
            next if right.nil?
            
            right.each { |x|
                result << [candidate] + x
            }
        end
    }
    
    result
end
