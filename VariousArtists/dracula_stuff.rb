# Counting sort
#

a = 0.upto(15).map {|x| [Random.rand(0..20), Random.rand(0..4)] }

counts = Array.new(a.map{ |x| x[0] }.max + 1, nil)
puts a.inspect

a.each { |x|
    counts[x[0]] ||= []
    counts[x[0]].push(x)
}

puts counts.size

t = counts.select{ |x| x }.inject([]) {|acc, x| acc + x }
puts t.inspect

