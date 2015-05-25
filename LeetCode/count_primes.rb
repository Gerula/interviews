# Count the number of prime numbers less than a non-negative number, n.
# Sieve of Eratostenes

primes = (2..200).inject({}){ |acc, x|
    acc[x] = true
    acc
}

primes.keys.each { |x|
    if primes[x]
        i = 2
        while i <= 200 / x
            primes[x * i] = false
            i += 1
        end
    end
}

puts primes.inspect
puts primes.values.count {|x| x}
