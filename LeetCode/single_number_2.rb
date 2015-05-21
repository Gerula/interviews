#  Given an array of integers, every element appears three times except for one. Find that single one. 
#

a = [1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 4]

puts a.select{ |x|
    a.count {|y|
        y==x
    } != 3
}.uniq
