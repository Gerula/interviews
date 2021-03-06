#   https://leetcode.com/problems/course-schedule-ii/
#
#   https://leetcode.com/submissions/detail/55360327/
#
#   Submission Details
#   36 / 36 test cases passed.
#       Status: Accepted
#       Runtime: 468 ms
#           
#           Submitted: 0 minutes ago
#
#   You are here!
#   Your runtime beats 71.43% of rubysubmissions.
# @param {Integer} num_courses
# @param {Integer[][]} prerequisites
# @return {Integer[]}
def find_order(num_courses, prerequisites)
    degrees = (0...num_courses).inject({}) { |acc, x|
        acc[x] = 0
        acc
    }
    
    direct, inverse = prerequisites.inject([{}, {}]) { |acc, x|
        acc[0][x[1]] ||= []
        acc[0][x[1]] << x[0]
        acc[1][x[0]] ||= []
        acc[1][x[0]] << x[1]
        degrees[x[0]] ||= 0
        degrees[x[0]] += 1
        acc
    }
    
    result = []
    while result.size < num_courses
        current = degrees.keys.select { |x| degrees[x] == 0 }
        return [] if current.empty?
        result += current
        current.each { |x|
            degrees.delete(x)
            next if direct[x].nil?
            direct[x].each { |y|
                degrees[y] -= 1
            }
        }
    end
    
    result
end

#   Stack level too deep
def find_order(num_courses, prerequisites)
    adj = prerequisites.reduce({}) { |acc, x|
        acc[x[1]] ||= []
        acc[x[1]] << x[0]
        acc
    }
    
    visiting, visited, result = {}, {}, []
    (0...num_courses).reduce(true) { |acc, i|
        acc & order(i, adj, visiting, visited, result)
    } ? result.reverse : []
end

def order(current, adj, visiting, visited, result)
    return false if visiting[current]
    return true if visited[current]
    visiting[current] = true
    forward = (adj[current] || []).reduce(true) { |acc, x|
        acc & order(x, adj, visiting, visited, result)
    }
    
    visited[current] = true
    visiting[current] = nil
    result << current
    return forward
end
