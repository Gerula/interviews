require 'test/unit'
extend Test::Unit::Assertions

class Fixnum
    def pow_3?
        return 3486784401 % self == 0
    end

    def pow_3_n?
        x = self

        while x % 3 == 0
            x /= 3
        end

        return x == 1
    end
end

3.upto(34867).each { |i|
        assert_equal(i.pow_3_n?, i.pow_3?, "For #{i}")
}
