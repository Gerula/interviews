class Array
    def max_sum
        self[1..-1].inject([self[0]]) { |acc, x|
            sum = ([1000] + acc + [1000]).flatten
            acc = x.each_with_index.map { |y, i|
                [y + sum[i], y + sum[i + 1]].min
            }
            acc
        }.min
    end
end

puts [   [2],
        [3, 4],
       [6, 5, 7],
      [4, 1, 8, 3]
].max_sum
