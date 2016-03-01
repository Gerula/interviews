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

#   https://leetcode.com/submissions/detail/54966024/
#   
#   Submission Details
#   16 / 16 test cases passed.
#       Status: Accepted
#   Runtime: 96 ms
#    
#   Submitted: 1 minute ago

def can_complete_circuit(gas, cost)
    total = 0
    trip = 0
    start = 0
    (0...gas.size).each { |i|
        trip += gas[i] - cost[i]
        total += trip
        if trip < 0
            trip = 0
            start = i + 1
        end
    }
    
    total < 0 ? - 1 : start
end
