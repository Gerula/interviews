class Bloom
    def initialize(hashes, size)
        @hashes = hashes
        @data = Array.new(size)
    end

    def <<(value)
        @hashes.each{ |hash|
            @data[hash.call(value) % @data.size] = 1
        }
    end

    def include?(value)
        @hashes.map { |hash|
            @data[hash.call(value) % @data.size]
        }.reduce { |acc, value|
            acc ||= 0
            acc += value.nil? ? 0 : 1 
        } == @hashes.length
    end
end

lambdas = []
primes = [997, 37, 271, 907]
primes.each { |prime|
    lambdas << lambda { |x|
        x.hash ^ prime
    }
}

bloom = Bloom.new(lambdas, 10)
bloom << "Yarp"
bloom << "http://isrubyfastyet.com"

puts bloom.inspect
puts bloom.include?("Yarp")
puts bloom.include?("http://isrubyfastyet.com")
puts bloom.include?("Test")

