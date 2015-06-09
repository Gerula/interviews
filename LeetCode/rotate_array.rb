a = Array(1..7) 
k = 3

k.times {
    a.unshift(a.pop)
}

puts a.inspect

a = Array(1..7) 

class Array
    def inverse(left, right)
        while left < right
            self[left], self[right] = self[right], self[left]
            left += 1
            right -= 1
        end
        
        self
    end
end

a.inverse(0, a.size - 1).inverse(0, k - 1).inverse(k, a.size - 1)
puts a.inspect
