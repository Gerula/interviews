#   https://www.reddit.com/r/dailyprogrammer/comments/4bc3el/20160321_challenge_259_easy_clarence_the_slow/

require 'test/unit'
extend Test::Unit::Assertions

class String
    def normalize
        case self
            when '.'
                9
            when '0'
                10
            else
                self.to_i - 1
        end
    end
end

def offset(a, b)
    a = a.normalize
    b = b.normalize
    Math.sqrt(((a / 3 - b / 3).abs ** 2 + (a % 3 - b % 3).abs ** 2).to_f)
end

def distance(str)
    distance = 0
    (1...str.size).each { |i|
        distance += offset(str[i], str[i - 1])
    }

    distance.round(2)
end

assert_same(27.38, distance("219.45.143.143"))
