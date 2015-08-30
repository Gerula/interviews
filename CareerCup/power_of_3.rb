require 'test/unit'
extend Test::Unit::Assertions

class Fixnum
    def pow_3?
        chars = self.to_s.chars
        return true if self == 3 || self == 0
        return (chars.last == '1' ||
                chars.last == "3" ||
                chars.last == "9" ||
                chars.last == "7") &&
                chars.map { |c| c.to_i }.reduce(:+) % 9 == 0
    end

    def pow_3_n?
        x = self

        while x > 1
            return false if x % 3 != 0
            x /= 3
        end

        return true
    end
end

3.upto(2 ** (0.size * 2)).each { |i|
        assert_equal(i.pow_3_n?, i.pow_3?, "For #{i}")
}
