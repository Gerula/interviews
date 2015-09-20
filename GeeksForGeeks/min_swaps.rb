# http://www.geeksforgeeks.org/minimum-number-of-swaps-required-for-arranging-pairs-adjacent-to-each-other/
#
# There are n-pairs and therefore 2n people. everyone has one unique number ranging from 1 to 2n.
# All these 2n persons are arranged in random fashion in an Array of size 2n. We are also given who is partner of whom.
# Find the minimum number of swaps required to arrange these pairs such that all pairs become adjacent to each other.
#

require 'test/unit'
extend Test::Unit::Assertions

def min_swaps(mapping, a)
    return -1 if a.size != mapping.size * 2
    mapping.merge!(mapping.inject({}) { |acc, x|
        acc[x[1]] = x[0]
        acc
    })

    indexes = a.each_with_index.inject({}) { |acc, x|
        acc[x[0]] = x[1]
        acc
    }

    return swaps(mapping, 0, a, indexes)
end

def swaps(mappings, idx, a, positions)
    return 0 if idx == a.size
    return swaps(mappings, idx + 2, a, positions) if mappings[a[idx]] == a[idx + 1] || mappings[a[idx + 1]] == a[idx]

    change_left = a.size
    if positions[mappings[a[idx]]] > idx
        swap(positions, a, idx + 1, positions[mappings[a[idx]]])
        change_left = 1 + swaps(mappings, idx + 2, a, positions)
        swap(positions, a, idx + 1, positions[mappings[a[idx]]])
    end

    change_right = a.size
    if positions[mappings[a[idx + 1]]] > idx
        swap(positions, a, idx, positions[mappings[a[idx + 1]]])
        change_right = 1 + swaps(mappings, idx + 2, a, positions)
        swap(positions, a, idx, positions[mappings[a[idx + 1]]])
    end

    return [change_left, change_right].min
end

def swap(positions, a, source, destination)
    a[source], a[destination] = a[destination], a[source]
    positions[a[source]], positions[a[destination]] = positions[a[destination]], positions[a[source]]
end

assert_equal(2, min_swaps({1 => 3, 2 => 6, 4 => 5}, [3, 5, 6, 4, 1, 2]))
