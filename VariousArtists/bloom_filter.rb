require 'Set'

class Bloom
    def initialize(hashes)
        @hashes = hashes
        @data = Set.new
    end

    def <<(value)
        @hashes.each{ |hash|
            @data << hash.call(value)
        }
    end

    def include?(value)
        @hashes.map { |hash|
           hash.call(value)
        }.inject(0){ |acc, value|
           acc += @data.include?(value)? 1 : 0
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

bloom = Bloom.new(lambdas)
bloom << "Yarp"
bloom << "http://isrubyfastyet.com"

puts bloom.inspect
puts bloom.include?("Yarp")
puts bloom.include?("http://isrubyfastyet.com")
puts bloom.include?("Test")

