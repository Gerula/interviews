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

powerset_iterative(set)
