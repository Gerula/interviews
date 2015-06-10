# Gray code because I forget
#
# The gray code is a binary numeral system where two successive values differ in only one bit.
#
# Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.
#
# For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:
#
# 00 - 0
# 01 - 1
# 11 - 3
# 10 - 2
#

n = 4

2.upto(n).inject([0,1]) { |agg, n|
    up = agg.map { |x| [0, x].flatten }
    down = agg.reverse.map { |x| [1, x].flatten }
    agg = up + down
}.each { |x|
    puts x.inspect
}
