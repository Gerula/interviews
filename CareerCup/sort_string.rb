# http://www.careercup.com/question?id=5647284379320320
#

require "test/unit"
extend Test::Unit::Assertions

class String
    def sort
        low = -1
        high = self.size
        undecided = 0
        while undecided < high
            if self[undecided].ord.between?("a".ord, "z".ord)
                low += 1
                self[low], self[undecided] = self[undecided], self[low]
                undecided += 1
            elsif self[undecided].ord.between?("A".ord, "Z".ord)
                high -= 1
                self[undecided], self[high] = self[high], self[undecided]
            else
                undecided += 1
            end
        end

        return self
    end
end

assert_equal("sdsdsd     DSASDFFA", "A ds ds FFDADS S ds".sort)
