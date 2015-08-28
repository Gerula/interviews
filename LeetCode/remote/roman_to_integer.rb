require 'test/unit'
extend Test::Unit::Assertions

def roman_to_int(s)
    counts  = { "M" => 3, "CM" => 1, "CD" => 1, "D" => 1, "C" => 3, "XC" => 1, "L" => 1, "XL" => 1, "X" => 3, "IX" => 1, "V" => 1, "IV" => 1, "I" => 3 }
    values = { "M" => 1000, "CM" => 900, "CD" => 400, "D" => 500, "C" => 100, "XC" => 90, "L" => 50, "XL" => 40, "X" => 10, "IX" => 9, "V" => 5, "IV" => 4, "I" => 1 }
    indexes = { "CM" => 1, "M" => 0, "CD" => 3, "D" => 2, "C" => 5, "XC" => 4, "L" => 7, "XL" => 6, "X" => 9, "IX" => 8, "V" => 11, "IV" => 10, "I" => 12 }
    value = 0
    prev = nil
    index = 0
    while !s.empty?
        symbol = values.keys.detect{ |x| s.start_with?(x) }

        return -1 if symbol.nil? || 
                     counts[symbol] == 0 ||
                     !prev.nil? && (indexes[symbol] < index || prev != symbol && indexes[symbol] == index)

        value += values[symbol]
        counts[symbol] -= 1
        s = s[symbol.size..-1]
        prev = symbol
        index = indexes[symbol]
    end

    return value
end

assert_equal(5, roman_to_int("V"))
assert_equal(-1, roman_to_int("IIII"))
assert_equal(1954, roman_to_int("MCMLIV"))
assert_equal(1990, roman_to_int("MCMXC"))
assert_equal(2014, roman_to_int("MMXIV"))
assert_equal(3999, roman_to_int("MMMCMXCIX"))
assert_equal(4, roman_to_int("IV"))
