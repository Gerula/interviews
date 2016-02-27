#   https://leetcode.com/problems/super-ugly-number/
#
#    Write a program to find the nth super ugly number.
#
#    Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k.
#    For example, [1, 2, 4, 7, 8, 13, 14, 16, 19, 26, 28, 32] is the sequence of the first 12 super ugly numbers given primes = [2, 7, 13, 19] of size 4. 

#   TLE and this was a fucking struggle. Completely forgot this one.
def nth_super_ugly_number(n, primes)
    hash = primes.inject({}) { |acc, x|
        acc[x] = 0
        acc
    }
    
    (1...n).inject([1]) { |acc, x|
        acc << hash.keys.map { |k| acc[hash[k]] * k }.min
        hash.keys.each { |k|
            hash[k] += 1 if acc.last == acc[hash[k]] * k
        }
        
        acc
    }
    .last
end

#   Optimized but still TLE. Well, this is the solution so i'm going to sleep.

def nth_super_ugly_number(n, primes)
    hash = {}
    result = [1]
    (n - 1).times {
        result << primes.map { |k| result[hash[k] || 0] * k }.min
        primes.each { |k|
            hash[k] ||= 0
            hash[k] += 1 if result.last == result[hash[k]] * k
        }
    }
    
    result[n - 1]
end
