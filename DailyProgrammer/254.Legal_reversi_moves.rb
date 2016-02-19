#   https://www.reddit.com/r/dailyprogrammer/comments/468pvf/20160217_challenge_254_intermediate_finding_legal/

require 'test/unit'
extend Test::Unit::Assertions

@competitor = { 'X' => 'O', 'O' => 'X', '*' => '*' } 

def move(table, player)
    n = table.size
    m = table[0].size

    result = 
    (0..n - 1)
    .to_a
    .product((0..m - 1)
             .to_a)
    .select { |x, y| 
        table[x][y] == @competitor[player] &&
        x != 0 && x != n - 1 &&
        y != 0 && y != m - 1
    }
    .map { |x, y| 
        (-1..1)
        .to_a
        .product((-1..1)
                .to_a)
        .select { |offsetx, offsety| 
            (offsetx != 0 || offsety != 0) &&
            @competitor[table[x + offsetx][y + offsety]].nil? &&
            find_player(table, player, x, y, -offsetx, -offsety)
        }
        .map { |offsetx, offsety|
            [x + offsetx, y + offsety]
        }
    }
    .flatten(1)
    .uniq
    

    result.each { |x, y|
        table[x][y] = '*'
    }

    puts table
    puts

    result.count
end

def find_player(table, player, x, y, offsetx, offsety)
    while (x.between?(0, table.size - 1) &&
           y.between?(0, table[0].size - 1))
        return true if table[x][y] == player
        x, y = x + offsetx, y + offsety
    end

    return false
end

[
[["--------",
  "--------",
  "--------",
  "---OX---",
  "---XO---",
  "--------",
  "--------",
  "--------"], 'X', 4],
[["--------",
  "--------",
  "---O----",
  "--XXOX--",
  "---XOO--",
  "----X---",
  "--------",
  "--------"], 'O', 11],
[["--------",
  "--------",
  "---OX---",
  "--XXXO--",
  "--XOO---",
  "---O----",
  "--------",
  "--------"], 'X', 12]].each { |test|
    assert_equal(test[2], move(test[0], test[1]))
}
