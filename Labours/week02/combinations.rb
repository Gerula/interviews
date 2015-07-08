def combinations(n, result, k, step)
    if result.size == k
        puts result.inspect
    end

    step.upto(n).each { |i|
        combinations(n, result + [i], k, i + 1)
    }
end

combinations(4, [], 2, 1)

