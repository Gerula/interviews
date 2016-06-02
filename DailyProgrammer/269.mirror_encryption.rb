#   https://www.reddit.com/r/dailyprogrammer/comments/4m3ddb/20160601_challenge_269_intermediate_mirror/

    require 'test/unit'
    extend Test::Unit::Assertions

    key = File.readlines("269.in")
        .each_with_index
        .map { |x, i|
            ('A'.ord + i).chr + x.chomp + ('n'.ord + i).chr
        }
        .unshift(" " + ('a'..'m').to_a.join + " ")
        .push(" " + ('N'..'Z').to_a.join + " ")

    class Position < Struct.new(:line, :column)
        def next(letter)
            case letter
                when '/'  then self.line, self.column = -self.column, -self.line
                when '\\' then self.line, self.column = self.column, self.line
            end

            return self
        end

        def move(offset)
            self.line += offset.line
            self.column += offset.column
            return self
        end
    end

    def get_start(letter, n)
        return case letter
            when 'a'..'m' then [Position.new(0, letter.ord - 'a'.ord + 1),     Position.new(1, 0)]
            when 'n'..'z' then [Position.new(letter.ord - 'n'.ord + 1, n - 1), Position.new(0, -1)]
            when 'A'..'M' then [Position.new(letter.ord - 'A'.ord + 1, 0),     Position.new(0, 1)]
            when 'N'..'Z' then [Position.new(n - 1, letter.ord - 'N'.ord + 1), Position.new(-1, 0)]
        end
    end

    all_letters = (('a'..'z').to_a + ('A'..'Z').to_a)
    starts = all_letters.reduce({}) { |acc, x|
        start = get_start(x, key.size)
        acc[x] = start
        acc
    }

    mapping = all_letters.reduce({}) { |acc, x|
        position, offset = starts[x]
        position.move(offset)

        while key[position.line][position.column] !~ /[[:alpha:]]/
            offset = offset.next(key[position.line][position.column])
            position.move(offset)
        end

        acc[x] = key[position.line][position.column]
        acc
    }

    def decrypt(mapping, message)
        message.chars.map { |x| mapping[x] }.join
    end

    assert_equal("DailyProgrammer", decrypt(mapping, "TpnQSjdmZdpoohd"))
