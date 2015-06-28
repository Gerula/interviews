# Find the most frequent element in an array in O(log N)

class Array
    def freq
        hash = self.inject({}) { |acc, c|
                count = self.count{ |x| x == c }
                acc[count] ||= []
                acc[count] << c
                acc
               }
        
        hash[hash.keys.max].first
    end
end

[[1, 1, 2], [2, 2, 3, 3, 3, 4], [1, 1, 2, 1, 2, 3, 1]].each { |x|
    puts "#{x} = #{x.freq}"
}
