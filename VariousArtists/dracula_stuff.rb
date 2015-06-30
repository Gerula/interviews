# Counting sort
#

a = 0.upto(15).map {|x| Random.rand(0..20) }
puts a.inspect

k = 5
c = 0
counts = Array.new(a.max + 1, 0)
a.each { |x|
    if c == k 
        puts "#{k}th element is #{x}"
    end
    c += 1
    counts[x] += 1
}

1.upto(counts.size - 1).each { |i|
    counts[i] += counts[i - 1]   
}

t = []
a.each { |x|
    t[counts[x] - 1] = x;
    counts[x] -= 1
}

puts t.inspect

