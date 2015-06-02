def pascal(n)
    (1..n).inject([]) { |acc, i|
        if acc.empty?
            [1]
        else
            current = []
            0.upto(i - 1).each { |j|
                prev_correspondent = j == 0 ? 0 : acc[j - 1]
                correspondent = j == i - 1 ? 0 : acc[j]
                current[j] = prev_correspondent + correspondent
            }
            current
        end
    }
end

puts pascal(1).inspect
puts pascal(2).inspect
puts pascal(3).inspect
puts pascal(4).inspect
puts pascal(5).inspect
