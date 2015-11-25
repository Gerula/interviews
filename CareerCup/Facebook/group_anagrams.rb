# http://careercup.com/question?id=5723872416497664
#
# Given a group of strings, group them by anagrams
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def group_anagrams
        self.inject({}) { |acc, x|
            acc[x.chars.sort] ||= []
            acc[x.chars.sort] << x
            acc
        }.values
    end
end

assert_equal([["cars", "arcs"], ["bike"], ["trees", "steer"]], ["cars", "arcs", "bike", "trees", "steer"].group_anagrams) 
