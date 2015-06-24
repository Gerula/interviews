def dist(s, t)
    a = Array.new(s.size + 1).map {
        Array.new(t.size + 1).map { 0 }
    }
    
    0.upto(s.size - 1).each { |i|
        a[i][0] = i
    }

    0.upto(t.size - 1).each { |i|
        a[0][i] = i
    }

    1.upto(s.size).each { |i|
        1.upto(t.size).each { |j|
           if s[i - 1] == t[j - 1]
              a[i][j] = a[i - 1][j - 1]
           else
              a[i][j] = [a[i - 1][j] + 1,
                         a[i][j - 1] + 1,
                         a[i - 1][j - 1] + 1].min 
           end 
        }
    }

    a[s.size][t.size]
end


[["islander", "slander"],
 ["mart", "karma"],
 ["KITTEN", "SITTING"],
 ["INTENTION", "EXECUTION"]].each { |x|
    puts "#{x[0]}:#{x[1]} - #{dist(x[0], x[1])}"
}
