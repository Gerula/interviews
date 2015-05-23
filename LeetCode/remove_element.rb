# Given an array and a value, remove all instances of that value in place and return the new length.
#
# The order of elements can be changed. It doesn't matter what you leave beyond the new length. 
#

def remove(a, value)
    write_index = 0
    occurences = 0
    0.upto(a.length-1).each {|i|
        if a[i] == value
            occurences += 1
        else
            a[write_index] = a[i]
            write_index += 1
        end
    }

    return a[0, a.length - occurences]
end


[[1, 1, 2, 3, 4, 5, 6, 7, 1, 2, 1, 4],
 [1, 3, 7, 1, 4]].each { |x|
    puts "#{x.inspect} #{remove(x, 1)}"
}
