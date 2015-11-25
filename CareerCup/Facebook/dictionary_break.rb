# http://careercup.com/question?id=5705581721550848
#
# Given a dictionary of strings check to see if a string
# is composed of arbitrary concats of elements from that dictionary
#

require 'test/unit'
extend Test::Unit::Assertions

class String
    def composed(dict, hash = nil)
        hash ||= {}
        next_result = (1..self.size)
                        .map{ |x| self[0, x] }
                        .select { |y| !dict[y].nil? }
                        .map { |z|
                            nextvalue = self[z.size + 1..-1]
                            if nextvalue.nil? || nextvalue.size == 0
                                    return true
                            else
                                    self[z.size + 1..-1].composed(dict, hash) 
                            end
                        }

        return next_result.empty? ? false : next_result.reduce(:|)
    end
end

dict = {"world" => 1, "helo" => 1, "super" => 1, "hell" => 1}
assert_equal(true, "helloworld".composed(dict))
assert_equal(false, "superman".composed(dict))
assert_equal(true, "hellohello".composed(dict))
