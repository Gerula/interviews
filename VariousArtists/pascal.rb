def pascal(n)
    (1..n).inject([]) { |acc, i|
        if acc.empty?
            [1]
        else
            current = [1]
            1.upto(i - 2).each { |j|
                current[j] = acc[j - 1] + acc[j] 
            }
            current + [1]
        end
    }
end

puts pascal(1).inspect
puts pascal(2).inspect
puts pascal(3).inspect
puts pascal(4).inspect
puts pascal(5).inspect
