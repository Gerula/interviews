def zeroes(n)
    result = 0
    i = 5
    while n / i > 0 
        result += n / i
        i *= 5
    end

    return result
end

puts zeroes(5)
puts zeroes(6)
puts zeroes(15)
puts zeroes(10)

