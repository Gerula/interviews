# Suppose a sorted array is rotated at some pivot unknown to you beforehand.
#
# (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
#
# Find the minimum element.
#
# You may assume no duplicate exists in the array.
#

def min(a)
    left = 0
    right = a.length - 1 

    while left < right
        if a[left] < a[right]
           return a[left]
        end

        if right - left == 1
            return [a[right], a[left]].min
        end

        mid = left + (right - left) / 2

        if a[left] > a[mid]
            right = mid
        else
            left = mid
        end
    end
end

[[4, 5, 6, 7, 0, 1], [0, 1, 2, 3, 4], [4, 0, 1, 2, 3]].each {|x|
    puts "#{x.inspect} - #{min(x)}"
}



