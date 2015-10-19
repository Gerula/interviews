# https://www.reddit.com/r/dailyprogrammer/comments/3ofsyb/20151012_challenge_236_easy_random_bag_system/
# Contrary to popular belief, the tetromino pieces you are given in a game of Tetris are not randomly selected.
# Instead, all seven pieces are placed into a "bag".
# A piece is randomly removed from the bag and presented to the player until the bag is empty.
# When the bag is empty, it is refilled and the process is repeated for any additional pieces that are needed.
#
# In this way, it is assured that the player will never go too long without seeing a particular piece.
# It is possible for the player to receive two identical pieces in a row, but never three or more. Your task for today is to implement this system. 
#

require 'test/unit'
extend Test::Unit::Assertions

def validate(output)
    return output.chars.each_cons(7).map{ |x| x == x.uniq }.reduce(:&)
end

def generate(n)
    mapping = { 
                0 => "O",
                1 => "I",
                2 => "S",
                3 => "Z",
                4 => "L",
                5 => "J",
                6 => "T"
              }
    
    result = ""
    random = Random.new
    (n / mapping.size).times {
        mapping.size.times {
            result += mapping[random.rand(0..100) % 7]
        }
    }

    (n % mapping.size).times {
        result += mapping[random.rand(0..100) % 7]
    }

    puts result
    result
end

20.times {
    assert(generate(50))
}
