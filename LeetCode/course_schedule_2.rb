#  There are a total of n courses you have to take, labeled from 0 to n - 1.
#
#  Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
#
#  Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
#

n = 4
a = [[1,0],[2,0],[3,1],[3,2]]

hash = a.inject({}) { |acc, x|
    acc[x[0]] ||= []
    acc[x[0]].push(x[1])
    acc
}

inverted_hash = hash.each_with_object({}) {|(key, value), out|
    out[value] ||= []
    out[value].push(key)
}

result_set = Array(0.upto(n-1))

while result_set.any?
    partial_result = result_set.select{|x|
        inverted_hash[x].nil? || !inverted_hash[x].any?
    }

    if !partial_result.any?
        raise("No solution")
    end

    result_set -= partial_result
    puts "#{partial_result.inspect} - in this run"
    partial_result.each{|x|
        hash[x].each{ |y|
            inverted_hash[y].remove(x) unless inverted_hash[y].nil?
        } unless hash[x].nil?
    }
end

puts hash.inspect
puts inverted_hash.inspect
