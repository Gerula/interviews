# Counting sort
#

a = 0.upto(15).map {|x| Random.rand(0..20) }
puts a.inspect

counts = Array.new(a.max + 1, 0)
a.each { |x|
    counts[x] += 1
}

t = counts.each_with_index.map { |x, i|
    if x != 0
        Array.new(x, i)
    else
        nil
    end
}.select { |x| x != nil }.flatten!

puts t.inspect

