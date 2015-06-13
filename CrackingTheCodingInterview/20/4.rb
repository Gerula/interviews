# Write a method to count the number of 2s between 0 and n.

n = 1000000
require 'benchmark'

puts "--- naive version ---"
time = Benchmark.measure {
    count = 0
    0.upto(n).each { |i|
        count += i.to_s.chars.count{|x| x=='2'}
    }

    puts count
}

puts time
puts "--- /naive version ---"
