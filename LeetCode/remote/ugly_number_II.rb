require 'test/unit'
extend Test::Unit::Assertions

# https://leetcode.com/submissions/detail/37365039/
# 596 / 596 test cases passed.
#   Status: Accepted
#   Runtime: 296 ms
#       
#   Submitted: 0 minutes ago
#
def nth_ugly_number(n)
    return 1 if n <= 1
    i2, i3, i5 = 0, 0, 0
    values = [1]
    for i in 1..n
        values[i] = [values[i2] * 2, values[i3] * 3, values[i5] * 5].min
        i2 += 1 if values[i] == values[i2] * 2
        i3 += 1 if values[i] == values[i3] * 3
        i5 += 1 if values[i] == values[i5] * 5
    end

    return values[n - 1]
end

# https://leetcode.com/submissions/detail/37364868/
# Time limit exceeded
# Solution is fine (relatively) but really slow
def nth_ugly_number_2(n)
    return 1 if n <= 1
    hash = {1 => true}
    start = 1
    count = 1
    while count <= n
        while hash[start].nil?
            start += 1
        end

        hash[start * 2] = true
        hash[start * 3] = true
        hash[start * 5] = true
        count += 1
        start += 1
    end

    return start - 1
end

ugly_numbers = [1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, 16, 18, 20, 24, 25, 27, 30, 32, 36, 40, 45, 48, 50, 54, 60, 64, 72, 75, 80, 81, 90, 96, 100]

0.upto(ugly_numbers.size - 1).each { |i|
    assert_equal(ugly_numbers[i], nth_ugly_number(i + 1))
    assert_equal(ugly_numbers[i], nth_ugly_number_2(i + 1))
}
