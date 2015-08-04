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

def anagrams_ninja(s, t)
    small = s.chars.inject({}) { |acc, c|
        acc[c] ||= 0
        acc[c] += 1
        acc
    }
    to_consume = small.dup
    
    result = []
    start = 0
    found = false
    large = {}
    0.upto(t.size - 1).each { |end_idx|
        c = t[end_idx]
        unless small[c].nil?
            large[c] ||= 0
            large[c] += 1
        end

        unless found
             to_consume[c] -= 1 if to_consume[c]
             to_consume.delete(c) if to_consume[c] && to_consume[c] == 0
             found = to_consume.size == 0
        end 

        new_start = false
        while small[t[start]].nil? || large[t[start]] > small[t[start]]
            large[t[start]] -= 1 unless small[t[start]].nil?
            start += 1
            new_start = true
        end

        result << start if found && small.size == large.size && (new_start || start == 0)
    }    

    result
end

assert_equal([0, 1, 2, 6], anagrams("abc", "bcabcxcba"))
assert_equal([0, 1, 2, 6], anagrams_ninja("abc", "bcabcxcba"))
