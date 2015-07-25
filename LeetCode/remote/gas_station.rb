# https://leetcode.com/submissions/detail/34132437/

# @param {Integer[]} gas
# @param {Integer[]} cost
# @return {Integer}
def can_complete_circuit(gas, cost)
    carry = 0
    status = [0, 0]
    1.upto(gas.size - 1).each { |i|
        carry += gas[i - 1] - cost[i - 1]
        if carry < status[1]
            status = [i, carry]
        end
    }
    
    carry += gas[gas.size - 1] - cost[gas.size - 1]
    return carry >= 0 ? status.first : -1
end
