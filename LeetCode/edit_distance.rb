def edit_dist(a, b)
    d = Array.new(a.size + 1).map{ |x| Array.new(b.size + 1).map { |y| 0 }}

    0.upto(b.size - 1).each { |i| 
        d[a.size][i] = i + 1
    }

    0.upto(a.size - 1).each { |i|
        d[i][b.size] = i + 1
    }

    (a.size - 1).downto(0).each { |x|
        (b.size - 1).downto(0).each { |y|
            d[x][y] = a[x] == b[y] ? d[x + 1][y + 1] : [d[x + 1][y], d[x][y + 1], d[x + 1][y + 1]].min + 1
        }
    }

    return d[0][0]
end

[["ISLANDER", "SLANDER", 1], ["MART", "KARMA", 5], ["KITTEN", "SITTING", 5], ["INTENTION", "EXECUTION", 8]].each { |x|
    puts "#{x.inspect}, #{edit_dist(x[0], x[1])}"
}
