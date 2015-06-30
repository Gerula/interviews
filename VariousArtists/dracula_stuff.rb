# Counting sort
#

a = 0.upto(15).map {|x| Random.rand(0..20) }
puts a.inspect

counts = Array.new(a.max + 1, 0)
a.each { |x|
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

puts a.sort.inspect
puts t.inspect
