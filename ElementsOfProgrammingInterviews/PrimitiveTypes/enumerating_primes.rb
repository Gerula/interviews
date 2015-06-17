class Primes
    def initialize(n)
        @n = n
        @primes = [2]
    end


    def is_prime(x)
        @primes.find{ |a| x % a == 0 }.nil?
    end

    def primes
        3.upto(@n).each { |i|
            if is_prime(i)
                @primes << i
                yield i
            end
        }
    end
end

primes = Primes.new(30)

primes.primes { |x|
    print("#{x} ")
}

puts
