# Gray code
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

def permutations(a, i)
    if i == a.size 
        puts to_decimal(a)
        gets
        return
    end

    for j in i..a.size-1
        a[j], a[i] = a[i], a[j]
        permutations(a, i + 1)
        a[j], a[i] = a[i], a[j]
    end
end

def to_decimal(a)
    result = 0
    a.reverse.each_with_index {|x, i|
        result += (2 ** i) * x
    }
    result
end

def gray(n)
    result = [0]
    n.times {
        size = result.size
        (size - 1).downto(0).each { |j|
            result << result[j] + size
        }
    }

    puts result
end

gray(0)
