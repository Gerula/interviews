#  Given a set of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.
#
#  The same repeated number may be chosen from C unlimited number of times.
#
#  Note:
#
#      All numbers (including target) will be positive integers.
#      Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
#      The solution set must not contain duplicate combinations.
#

def combinations(candidates, i, solution, target, sum)
    if sum == target
        puts solution.inspect
        return
    end

    i.upto(candidates.size - 1).each { |i|
        if candidates[i] > target - sum
            return
        end

        solution << candidates[i]
        combinations(candidates, i, solution, target, sum + candidates[i])
        solution.pop
    }
end

combinations([7, 6, 3, 2], 0, [], 7, 0)
