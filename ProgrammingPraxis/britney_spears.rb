# Misra - Gries algorithm
# for determining the most frequent n elements in a stream
#

class Frequency
    def initialize(n)
        @size = n
        @data = {}
        @frequencies = []
    end

    def record(value)
        puts "Recording #{value}"
        if @data[value]
            @data[value] += 1
        elsif @frequencies.size < @size
            @data[value] = 1
            @frequencies << value
        else
            puts @data.inspect
            @frequencies.each { |x|
                @data[x] -= 1
            }
            
            @frequencies.delete_if {|x| @data[x] == 0}    
        end
    end

    def query
        @frequencies.dup
    end
end

#freq = Frequency.new(2)
#Random.rand(10..200).times {
#    freq.record(Random.rand(1..10))
#    puts freq.query.inspect
#}

puts "Space saving"

class SpaceSaving
    def initialize(n)
        @size = n
        @min_hits = n
        @frequencies = {}
    end

    def record(value)
        puts "Recording #{value}"
        if @frequencies[value]
            @frequencies[value] += 1
            @min_hits = [@frequencies[value], @min_hits].min
        elsif @frequencies.size < @size
            @frequencies[value] = 1
            @min_hits = 1
        else
            @frequencies.delete(@frequencies.keys.first {|key| @frequencies[key] == @min})
            @frequencies[value] = 1
            @min_hits = 1
        end
    end

    def query
        @frequencies.dup
    end
end

freq = SpaceSaving.new(3)
Random.rand(10..200).times {
    freq.record(Random.rand(1..10))
    puts freq.query.inspect
}
