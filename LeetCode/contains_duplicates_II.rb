class Array
    def dupe(k)
        hash = {}
        result_hash = {}
        
        self.each.with_index { |x, index|
            if !hash[x].nil?
                diff = index - hash[x]
                if diff <= k
                    result_hash[diff] ||= []
                    result_hash[diff] << [x, [hash[x], index]]
                end
            end   

            hash[x] = index
        }

        result_hash
    end
end

puts [1, 3, 1, 2, 3].dupe(3).inspect
