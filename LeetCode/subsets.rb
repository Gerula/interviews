# Powerset
#

def powerset(set, pos, result)
    puts result.inspect

    pos.upto(set.size - 1).each { |i|
        result << set[i]
        powerset(set, i + 1, result)
        result.pop
    }
end

powerset([1, 2, 3], 0, [])
