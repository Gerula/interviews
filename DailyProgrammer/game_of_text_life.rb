# https://www.reddit.com/r/dailyprogrammer/comments/3m2vvk/20150923_challenge_233_intermediate_game_of_text/
#

class Board
    def initialize(lines)
        max = lines.map{ |x| x.size }.max
        @storage = Array.new(lines.length) {
            Array.new(max) {
                ""
            }
        }

        for i in 0...lines.size
            for j in 0...max
                @storage[i][j] = j < lines[i].size ? lines[i][j] : ""
            end
        end
    end

    def next
        transformed = @storage.dup
        for i in 0...transformed.size
            transformed[i].push("")
        end

        transformed.push("")
        puts @storage.inspect

        for i in 0...transformed.size
            for j in 0...transformed[0].size
                cell_neighbors = neighbors(i, j)
                if transformed[i][j].nil? || transformed[i][j] == ""
                    transformed[i][j] = cell_neighbors.size == 3 ?
                                        cell_neighbors[Random.rand(cell_neighbors.size)] : ""
                else
                    transformed[i][j] = cell_neighbors.size == 2 ||
                                        cell_neighbors.size == 3 ?
                                        transformed[i][j] : ""
                end
            end
        end

        @storage = transformed
    end

    def neighbors(i, j)
        offsets = [[-1, -1], [-1, 0], [-1, 1],
                   [0, -1],           [0, 1],
                   [1, -1], [1, 0], [1, 1]]

        result = []
        offsets.each { |x| 
            result << @storage[x[0] + i][x[1] + j] if
            (x[0] + i).between?(0, @storage.size - 1) &&
            (x[1] + j).between?(0, @storage[0].size - 1) &&
            @storage[x[0] + i][x[1] + j] != ""
        }
        
        return result
    end

    def to_s
        @storage.each { |x|
            puts x.join("")
        }
    end
end

board = Board.new(["The basic idea is this: the game takes place on",
                   "an infinite 2D grid of cells. Cells can be either \"alive\" or \"dead\".",
                   "The game evolves in generations,",
                   "where old cells die out or are born again according to very simple rules."])
100.times {
    sleep(0.5)
    system "clear" or system "cls"
    puts board
    board.next
}
