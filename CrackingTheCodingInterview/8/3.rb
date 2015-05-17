# Write a method that returns all subsets of a set.
#

set = "123"

def powerset_iterative(set)
    (0..2<<set.length).each do |i|
        result = []
        (0..set.length).each do |j|
            if i & (1<<j) != 0
                result.push(set[j])
            end
        end
        puts result.join()
    end
end

def powerset_recursive(set)
    return if !set.any?
    puts set.inspect
    (0..set.size - 1).each do |i|
        powerset_recursive(set - [set[i]])
    end 
end

#powerset_iterative(set)
powerset_recursive(set.split(""))
