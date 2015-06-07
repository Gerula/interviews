# shuffle deck of cards
#

array = Array(1..10)

0.upto(array.size - 2).each { |i|
    target = Random.rand((i + 1)..(array.size-1))
    array[target], array[i] = array[i], array[target]
}

puts array.inspect
