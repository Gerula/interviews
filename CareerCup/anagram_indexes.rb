require 'test/unit'
extend Test::Unit::Assertions

class Rolling
    attr_reader :number, :hash

    def initialize
        @number = 0
        @hash = {}
    end

    def add(c)
        @number += c.ord
        @hash[c] ||= 0
        @hash[c] += 1
    end

    def remove(c)
        @number -= c.ord
        @hash[c] -= 1
        @hash.delete(c) if @hash[c] == 0
    end

    def equals_to(other)
        return @number == other.number && @hash == other.hash
    end
end

def anagrams(s, t)
    result = []
    small = Rolling.new
    s.chars.each{ |c|
        small.add(c)
    }

    large = Rolling.new
    0.upto(s.size - 1).each { |i|
        large.add(t[i])
    }

    result << 0 if small.equals_to(large)

    s.size.upto(t.size - 1).each { |i|
        large.add(t[i])
        large.remove(t[i - s.size])
        result << i - s.size + 1 if small.equals_to(large)
    }

    return result
end

assert_equal([0, 1, 2, 6], anagrams("abc", "bcabcxcba"))
