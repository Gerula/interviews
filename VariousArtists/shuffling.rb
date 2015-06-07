# shuffle deck of cards
#

perm = Array(0..4)

0.upto(perm.size - 2).each { |i|
    target = Random.rand((i + 1)..(perm.size-1))
    perm[target], perm[i] = perm[i], perm[target]
}

array = ["zero", "one", "two", "three", "four"]

puts perm.inspect

0.upto(perm.size - 1).each { |i|
    while perm[i] != i && perm[i] < perm[perm[i]]
        x = perm[i]
        perm[i], perm[x] = perm[x], perm[i]
    end
}

puts perm.inspect
