# https://leetcode.com/submissions/detail/33979458/
#   
#   Submission Details
#       Status: Accepted
#       Runtime: 380 ms
#           
#           Submitted: 7 months, 1 week ago
#
# @param {Integer} num_courses
# @param {Integer[][]} prerequisites
# @return {Boolean}
def can_finish(num_courses, prerequisites)
    reverse = {}
    adjancency = prerequisites.inject({}) { |acc, c|
        acc[c[0]] ||= []
        acc[c[0]] << c[1]
        reverse[c[1]] ||= []
        reverse[c[1]] << c[0]
        acc
    }
    
    0.upto(num_courses - 1).each { |x|
        adjancency[x] ||= []
        reverse[x] ||= []
    }

    num_courses.times { 
        current = reverse.find{ |x, y| y.size == 0 }
        if current.nil?
            return false
        end
        
        puts reverse.delete(current[0])

        adjancency[current[0]].each { |x|
            reverse[x].delete(current[0])
        }
    }
    
    return true
end

#   faster
#   https://leetcode.com/submissions/detail/55008534/
#
#   Submission Details
#   35 / 35 test cases passed.
#       Status: Accepted
#       Runtime: 204 ms
#           
#           Submitted: 0 minutes ago
#
def dfs(visited, visiting, adj, current)
    return true if visited.include?(current)
    return false if visiting.include?(current)
    visiting << current
    result = adj[current].nil? ? 
                true : 
                adj[current].map { |x| dfs(visited, visiting, adj, x) }.inject(:&)
    visiting.pop
    visited << current
    return result
end

def can_finish(num_courses, prerequisites)
    adj = prerequisites.inject({}) { |acc, x|
        acc[x.last] ||= []
        acc[x.last] << x.first
        acc
    }
    
    visited = []
    visiting = []
    (0...num_courses).map { |x| dfs(visited, visiting, adj, x) }.inject(:&)
end
