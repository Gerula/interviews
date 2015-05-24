#  Write a method to sort an array of strings so that all the anagrams are next to each other.
#

puts ["abc", "dfg", "bca", "gfd"].sort!{ |x, y|
    if (x.split("").sort) == (y.split("").sort)
        0
    elsif x>y
        -1
    else
    1
    end
}
