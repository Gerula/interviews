#  Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column is set to 0.

a = [[1, 2, 0, 4, 0],
     [1, 2, 3, 0, 5],
     [1, 2, 3, 4, 5],
     [1, 2, 3, 4, 5],
     [1, 2, 3, 4, 5]]

class Array
    def print_to_c
        (0..self.size-1).each {|i|
            (0..self[i].size-1).each {|j|
                print "#{self[i][j]} "
            }
            puts
        }
        puts
    end
end

a.print_to_c

targets = {}

(0..a.size-1).each {|i|
    (0..a[i].size-1).each {|j|
        if a[i][j] == 0
            targets[i] ||= []
            targets[i].push(j)
        end
    }
}

targets.each {|i,j|
    (0..a.size-1).each {|column|
        a[i][column] = 0
    }

    j.each {|column|
        (0..a.size-1).each{|line|
            a[line][column] = 0
        }
    }
}

a.print_to_c
