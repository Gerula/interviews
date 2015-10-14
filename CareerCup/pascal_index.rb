# Find the value of (x, y) in Pascal's triangle.
# 
# 1
# 1 1
# 1 2 1
# 1 3 3 1
# 1 4 6 4 1
#
# F(4, 1) = 4
#

def pascal(x, y)
    return 0 if y < 0
    return 1 if x < 2 || y == x
    pascal(x - 1, y - 1) + pascal(x - 1, y)
end

puts pascal(4, 0)
puts pascal(4, 1)
puts pascal(4, 2)
puts pascal(4, 3)
puts pascal(4, 4)


