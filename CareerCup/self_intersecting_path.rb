# http://www.careercup.com/question?id=5143327210995712
#
# Alledgedly a phone interview question. Fucking hell...
#

require 'test\unit'
extend Test::Unit::Assertions

class Array
    def cross?
        # my initial idea was that we can keep a border for all 4 directions and if you 
        # cross that border, then return true. But this doesn't hold for something like below
        #  ________
        #  |  ____|
        #  |
        #
        #  So this is basically something related to the convex hull. 
        #  Clues: single pass (this doesn't really mean O(n))
        #  So I'm looking at the shit solutions on careercup to get a solid shitty understanding.
        #  But none of them came up with something workable. Need to do this on paper like some pleb.


    end
end

assert_true([2, 1, 2, 2].cross?)
assert_true(![1, 2, 3, 4].cross?)
