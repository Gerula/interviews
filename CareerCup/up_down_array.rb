require 'test/unit'
extend Test::Unit::Assertions

def generate
    size = Random.rand(5..12)
    return Array.new(size) {
        Random.rand(1..30)
    }
end

class Array
    def up_down?
        0.upto(self.size - 2).each { |i|
            return false if i % 2 == 0 && self[i] > self[i + 1] || i % 2 == 1 && self[i] < self[i + 1]
        }

        return true
    end

    def up_down
        return self
    end
end

a = generate
b = [3, 5, 0, 6, 2, 4, 1, 5]
puts "#{a.inspect} #{a.up_down?}"
puts "#{b.inspect} #{b.up_down?}"
