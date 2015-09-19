# https://www.reddit.com/r/dailyprogrammer/comments/3ggli3/20150810_challenge_227_easy_square_spirals/

require 'test/unit'
extend Test::Unit::Assertions

#  1 1 1 1 1 1 1 1 1
#  1 1 1 1 1 1 1 1 1
#  1 1 1 1 1 1 1 1 1
#  1 1 1 1 1 1 1 1 1            Size of current square:
#  1 1 1 1 1 1 1 1 1                                    
#  1 1 1 1 1 1 1 1 1             x 0 0 0        5 4 3                     
#  1 1 1 1 1 1 1 1 1               0 c 0        6 1 2 x          
#  1 1 1 1 1 1 1 1 1               0 0 0        7 8 9           
#  1 1 1 1 1 1 1 1 1                                    
#                                size = [(start[0] - x[0]).abs, (start[1] - x[1]).abs].max * 2 + 1    
#
#
# Size of the whole thing
#                                                                     
# 1 - 1                                            5 4 3                 
# 3 - 1 + 8                                        6 1 2                         
# 5 - 1 + 8 + 16                                   7 8 9      s(4, 5)                
# 7 - 1 + 8 + 16 + 24                                                                   
# 9 - 1 + 8 + 16 + 24 + 32                                                                      
# x = 1 + 8 + 16 + ... + (x - 1) * 4                                                                
# x = 1 + 8 * (1 + 2 + 3 + n), n = (x - 1)/2                                                    
# x = 1 + 8 * n * (n - 1) / 2                                                                               
# x = 1 + 4 * n * (n - 1)                                                                                                   

def get_value(size, x, y)
    center = [size / 2 + 1, size / 2 + 1]
    size_of_current_layer_edge  = ([(center[0] - x).abs, (center[1] - y).abs].max << 1) + 1 
    size_of_next_smaller_layer = 1 + 4 * ((size_of_current_layer_edge - 1) / 2) * ((size_of_current_layer_edge - 1) / 2 - 1) 
    size_of_next_smaller_layer_edge = Math.sqrt(size_of_next_smaller_layer).to_i
    range = size_of_current_layer_edge ** 2 - size_of_next_smaller_layer 

    new_start_value = size_of_next_smaller_layer + 1
    new_start = [(size - size_of_next_smaller_layer_edge) / 2 + size_of_next_smaller_layer_edge, (size - size_of_next_smaller_layer_edge) / 2 + size_of_next_smaller_layer_edge + 1]

    size_of_next_smaller_layer_edge.times {
        new_start_value += 1
        new_start[0] -= 1    
        return new_start_value if new_start == [x, y]
    }

    (size_of_next_smaller_layer_edge + 1).times {
        new_start_value += 1
        new_start[1] -= 1    
        return new_start_value if new_start == [x, y]
    }

    (size_of_next_smaller_layer_edge + 1).times {
        new_start_value += 1
        new_start[0] += 1    
        return new_start_value if new_start == [x, y]
    }

    (size_of_next_smaller_layer_edge + 1).times {
        new_start_value += 1
        new_start[1] += 1    
        return new_start_value if new_start == [x, y]
    }
end

def get_coordinates(size, n)
    
end

# disabling these tests for now
#
# assert_equal([2, 3], get_coordinates(3, 8))
# assert_equal([10, 9], get_coordinates(11, 50))
# assert_equal([512353188, 512346213], get_coordinates(1024716039, 557614022))
assert_equal(37, get_value(7, 1, 1))
assert_equal(47, get_value(9, 6, 8))
assert_equal(54790653381545607, get_value(234653477, 11777272, 289722))
