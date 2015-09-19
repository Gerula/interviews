require 'test/unit'
extend Test::Unit::Assertions

class Array
    def xwords
        # this.
        # this is a hard problem
    end
end

assert_equal(
"  NEAT
   O   
 LARGE 
   I   ",
   ["neat", "iron", "large"].xwords)
