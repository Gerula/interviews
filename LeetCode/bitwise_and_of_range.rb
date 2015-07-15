def and_range(a, b)
    mask = 2 ** 8 - 1
    while a & mask != b & mask
        mask <<= 1
    end

    return mask & a
end

puts and_range(5, 7)
