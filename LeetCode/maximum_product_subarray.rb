#  Find the contiguous subarray within an array (containing at least one number) which has the largest product.
#
#  For example, given the array [2,3,-2,4],
#  the contiguous subarray [2,3] has the largest product = 6. 
#

a = [2, 3, -2, 4]

puts (0..(a.size-1)).inject(a[0]) {|max_prod, current|
    (current..(a.size-1)).each { |i|
        max_prod = [a[current..i].reduce{ |acc, x| x*acc }, max_prod].max
    }
    max_prod
}


