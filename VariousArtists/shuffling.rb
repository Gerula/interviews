# shuffle deck of cards
#

perm = Array(0..4)

0.upto(perm.size - 2).each { |i|
    target = Random.rand((i + 1)..(perm.size-1))
    perm[target], perm[i] = perm[i], perm[target]
}

array = ["zero", "one", "two", "three", "four"]

puts perm.inspect

(0..(perm.size - 1)).each { |i|
    if perm[i] > 0 
        a = i
        temp = array[i]
        begin
            next_a = perm[a]
            next_temp = array[next_a]
            array[next_a] = temp
            perm[a] = -1
            a = next_a
            temp = next_temp
        end while a != i
    end
}

puts array.inspect
