#  Implement the “paint fill” function that one might see on many image editing pro- grams. That is, given a screen (represented by a 2 dimensional array of Colors), a point, and a new color, fill in the surrounding area until you hit a border of that col- or.’

def print_array(a)
    puts "--- Begin array printout ---"

    (0..a.length - 1).each { |i|
        (0..a[i].length - 1).each { |j|
            print "#{a[i][j]} "
        }
        puts
    }

    puts "--- End array printout ---"
end

def fill(position, a, color)
    if !position[0].between?(0, a.length - 1) ||
       !position[1].between?(0, a[0].length - 1)
        return
    end

    if a[position[0]][position[1]] == color
        return
    end

    a[position[0]][position[1]] = color

    [[-1, -1], [-1, 0], [-1, 1],
     [ 0, -1],          [ 0, 1],
     [ 1, -1], [ 1, 0], [ 1, 1]].each do |offset|
        fill((0..1).map { |i| position[i] + offset[i] }, a, color)
    end
end

a = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
     [0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]]

fill([3, 4], a, 1)

print_array(a)
