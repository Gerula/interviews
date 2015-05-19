# A friend of mine got this at Google.
#

a = [0, 5, 0, 10, 3, 2, 11]

def max_water_1(a)
    i = 0
    j = a.length - 1
    max_i = 0
    max_j = 0
    max_area = 0

    while i < j
        area = (j - i) * [a[i], a[j]].min
        if area > max_area
            max_area = area
            max_i = i
            max_j = j
        end

        if a[i] < a[j] 
            i += 1
        else
            j -= 1
        end
    end

    puts "#{max_i} - #{max_j} = #{max_area}"
end

max_water_1(a)
