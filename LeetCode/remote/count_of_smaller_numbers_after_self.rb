#   https://leetcode.com/problems/count-of-smaller-numbers-after-self/
#   You are given an integer array nums and you have to return a new counts array.
#   The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i]. 

require 'test/unit'
extend Test::Unit::Assertions

def count_smaller(nums)
    counts = Array.new(nums.size) { 0 }
    indexes = (0...nums.size).to_a
    merge_sort(indexes, nums, counts, 0, indexes.size - 1)
    puts "#{counts}"
    counts
end

def merge_sort(indexes, nums, counts, low, high)
    return if low >= high
    mid = low + (high - low) / 2
    merge_sort(indexes, nums, counts, low, mid)
    merge_sort(indexes, nums, counts, mid + 1, high)
    merge(indexes, nums, counts, low, mid, high)
end

def merge(indexes, nums, counts, low, mid, high)
    new_indexes = []
    k, i, j = 0, low, mid + 1
    right_count = 0
    while (i <= mid && j <= high)
        if nums[indexes[j]] < nums[indexes[i]]
            new_indexes[k] = indexes[j]
            i += 1
            right_count += 1
        else
            new_indexes[k] = indexes[i]
            counts[indexes[i]] += right_count
            j += 1
        end

        k += 1
    end

    while i < mid
        new_indexes[k] = indexes[i]
        counts[indexes[i]] += right_count
        i += 1
        k += 1
    end

    while j < high
        new_indexes[k] = indexes[j]
        j += 1
        k += 1
    end

    (low..high).each { |i|
        indexes[i] = new_indexes[i - low] || 0
    }
end

assert([2, 1, 1, 0] == count_smaller([5, 2, 6, 1]))
