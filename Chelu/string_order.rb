a = [["a1", "a2"], ["b1"], ["c1", "c2", "c3"]]
max = a.max { |x| x.size }.size

puts a.map { |x| 
    x.size < max ? x + [nil] * (max - x.size) : x
}.reduce { |acc, x|
    acc.zip(x)
}.flatten.compact.inspect

puts 0.upto(max).inject([]) { |acc, x|
        acc + a.map { |y|
                y[x]
              }
}.compact.inspect

