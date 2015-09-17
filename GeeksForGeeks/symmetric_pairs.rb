# http://www.geeksforgeeks.org/given-an-array-of-pairs-find-all-symmetric-pairs-in-it/

require 'test/unit'
extend Test::Unit::Assertions

def symmetric_pairs(array)
    hash = {}
    return array.inject([]) { |acc, x|
        acc << [[x[0], x[1]].min, [x[0], x[1]].max] if hash[x[1]] == x[0]
        hash[x[0]] = x[1]
        acc
    }
end

assert_equal([[30, 40], [5, 10]], symmetric_pairs([[10, 20], [30, 40], [5, 10], [40, 30], [10, 5]]))
