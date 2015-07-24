# https://leetcode.com/submissions/detail/33979458/

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
