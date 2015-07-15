def and_range(a, b)
    mask = 2 ** 8 - 1
    while a & mask != b & mask
        mask <<= 1
    end

    return mask & a
end

def and_range_2(a, b)
    offset = 0
    while a != b
        offset += 1 
        a >>= 1
        b >>= 1
    end

    return a << offset
end

puts and_range(5, 7)
puts and_range_2(5, 7)
