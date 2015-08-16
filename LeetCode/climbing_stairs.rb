require 'test/unit'
extend Test::Unit::Assertions

def climb_stairs(n)
    result = [0]
    climb(1, n, result)
    return result.first
end

def climb(current, n, result)
    if current == n
        result[0] += 1
        return
    end

    climb(current + 1, n, result) if current + 1 <= n
    climb(current + 2, n, result) if current + 2 <= n
end

assert_equal(3, climb_stairs(4))
assert_equal(5, climb_stairs(5))
assert_equal(8, climb_stairs(6))
assert_equal(13, climb_stairs(7))
assert_equal(21, climb_stairs(8))
assert_equal(34, climb_stairs(9))
assert_equal(55, climb_stairs(10))
