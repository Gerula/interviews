#  Given an unsorted integer array, find the first missing positive integer.
#
#  For example,
#  Given [1,2,0] return 3,
#  and [3,4,-1,1] return 2.
#
#  Your algorithm should run in O(n) time and uses constant space. 
#

def find_min(a)
    (0..(a.length-1)).each { |i|
        while a[i] > 0 && a[i] != a[a[i] - 1] && a[i] != i + 1
            aux = a[i]
            a[i] = a[a[i] -1]
            a[aux-1] = aux
        end
    }

    i = 0
    while (a[i] == i + 1)
        i += 1
    end

    i + 1
end

[[1, 2, 0], [3, 4, -1, 1]].each {|x|
    puts "#{x} - #{find_min(x)}"
}

