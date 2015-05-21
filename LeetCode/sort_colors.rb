#  Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.
#
#  Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively. 
#

colors = { 1 => "red", 2 => "white", 3 => "blue" }

array = (1..Random.rand(6..20)).map { |i|
    Random.rand(1..3)
}

puts array.inspect

small = -1
undecided = 0
large = array.length

while (undecided < large)
    case array[undecided]
    when 3
        large -= 1
        array[large], array[undecided] = array[undecided], array[large]
    when 2
        undecided += 1
    when 1
        small += 1
        array[small], array[undecided] = array[undecided], array[small]
        undecided += 1
    end
end

puts array.map {|x| colors[x] }.inspect
