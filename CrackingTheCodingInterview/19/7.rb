#  You are given an array of integers (both positive and negative). Find the continuous sequence with the largest sum. Return the sum.
#  EXAMPLE
#  Input: {2, -8, 3, -2, 4, -10}
#  Output: 5 (i.e., {3, -2, 4} )
#
#  This is classic Kadane

def max_seq(a)
    max_sum = a[0]
    max_start = 0
    max_end = 0
    start_index = 0
    end_index = 0
    partial_max = a[0]
    1.upto(a.length - 1).each { |i|
        end_index += 1
        
        if partial_max + a[i] > 0
            partial_max = partial_max + a[i]
        else
            partial_max = 0
            start_index = i + 1
        end

        if max_sum < partial_max
            max_sum = partial_max
            max_start = start_index
            max_end = end_index
        end
    }

    puts "#{max_start} - #{max_end}"
    return max_sum
end

[[2, -8, 3, -2, 4, -10], [3, -2, 4]].each { |x|
    puts "#{x.inspect} - #{max_seq(x)}"
}
