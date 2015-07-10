class Fixnum
    def sparse?
        return ((self.abs * 2) & self.abs == 0)
    end

    def next_sparse
        (self + 1).upto(2 ** (0.size * 8 - 2)).find { |x| x.sparse? }
    end
end

max = 1000
Random.rand(max).times {
    number = Random.rand(max)
    puts "For #{number} next sparse is #{number.next_sparse}"
}
