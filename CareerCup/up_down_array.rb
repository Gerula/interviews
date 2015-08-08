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
        0.upto(self.size - 2).each { |i|
            if i % 2 == 0 && self[i] > self[i + 1]
                self[i], self[i + 1] = self[i + 1], self[i]
            end

            if i % 2 == 1  && self[i] < self[i + 1]
                self[i], self[i + 1] = self[i + 1], self[i]
            end
        }

        return self
    end
end

Random.rand(5..15).times {
    a = generate
    puts a.inspect
    puts "#{a.up_down.inspect} #{a.up_down?}"
    assert(a.up_down?)
}
