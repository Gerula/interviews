require 'test/unit'
extend Test::Unit::Assertions

def bin_search(a, k)
    offset = 0
    length = a.size
    c = 0
    while length > 0
        c += 1
        half = length / 2
        index = offset + half
        case
        when a[index] == k
            puts "#{a.size} #{c}"
            return index
        when a[index] < k
            offset = index 
        end 
        length = half
    end

    puts "#{a.size} #{c}"
    return -1
end

assert_equal(-1, bin_search([], 0))
assert_equal(-1, bin_search([1], 0))
assert_equal(-1, bin_search([1, 2], 3))
assert_equal(-1, bin_search([1, 2], 0))
assert_equal(-1, bin_search([1, 2, 3], 0))
assert_equal(-1, bin_search([1, 2, 3], 4))
assert_equal(0, bin_search([1, 2, 3], 1))
assert_equal(3, bin_search([1, 2, 3, 4], 4))
assert_equal(6, bin_search([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 7))
assert_equal(3, bin_search([-1, 0, 1, 2, 3, 4], 2))
assert_equal(-1, bin_search([-1, 1, 2, 3, 4], 0))
