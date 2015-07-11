puts 1.upto(100000).count { |x| 
    x.to_s.split('').count { |y| y.to_i % 2 == 1} % 2 == 0
}
