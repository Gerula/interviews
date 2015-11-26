# http://careercup.com/question?id=65732
#
# Given a list of numbers,
# produce a grouping of consecutive numbers
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def consec
        hash = self.inject({}) { |acc, x|
            acc[x] ||= []
            acc[x] = true
            acc
        }

        return (0...self.size).inject([]) { |acc, x|
            up, down = self[x] + 1, self[x] - 1
            return acc if hash[self[x]].nil?
            res = [self[x]]
            while hash[up]
                res << up
                hash.delete(up)
                up += 1
            end

            while hash[down]
                res << down
                hash.delete(down)
                down -= 1
            end

            acc << res.sort
            acc
        }
    end
end

assert_equal([[2, 4, 1, 0, 3].sort, [8, 6, 7].sort].sort, [8, 2, 4, 7, 1, 0, 3, 6].consec.sort)
