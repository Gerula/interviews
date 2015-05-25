#  We have an array of integers, where:
#
#    The integers are in the range 1..n1..n1..n
#    The array has a length of n+1n+1n+1
#
# It follows that our array has at least one integer which appears at least twice. But it may have several duplicates, and each duplicate may appear more than twice. 
#

def find_dup(a)    
    0.upto(a.length - 1).each {|i|
        while a[i] != i + 1 && !a[i].nil?
            if a[a[i] - 1] == a[i]
                return a[i]
            end
            aux = a[i]
            a[i] = a[aux - 1]
            a[aux - 1] = aux 
        end
    }
    a.inspect
end

[[1, 2, 3, 4, 2], [2, 3, 1, 3]].each {|x|
    puts "#{x.inspect} - #{find_dup(x)}"
}

        
 
