#  Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
#

a = [[1, 2, 3, 4, 5],
     [6, 7, 8, 9, 0],
     [1, 2, 3, 4, 5],
     [6, 7, 8, 9, 0],
     [1, 2, 3, 4, 5]]

n = 5

def print_array(a, n)
    (0..n-1).each { |i|
        (0..n-1).each { |j|
            print a[i][j], " "
        }
    puts
    }
    puts
end

def rotate_array(a, n)
    for i in 0..n/2 
        for j in i..n-i-2
            aux = a[i][j]
            a[i][j] = a[j][n - i - 1]
            a[j][n - i - 1] = a[n - i - 1][n - j - 1]
            a[n - i - 1][n - j - 1] = a[n - j - 1][i]
            a[n - j - 1][i] = aux
        end
    end
end

print_array(a, n)
rotate_array(a, n)
print_array(a, n)

