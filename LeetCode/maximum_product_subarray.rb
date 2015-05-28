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

max_local = a.first
min_local = a.first
max_global = a.first

a[1..-1].each { |x|
    max = max_local
    max_local = [[max_local * x, x].max, min_local * x].max
    min_local = [[max * x, x].min, min_local * x].min
    max_global = [max_local, max_global].max 
}

puts max_global
