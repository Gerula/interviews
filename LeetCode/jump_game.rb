#  Given an array of non-negative integers, you are initially positioned at the first index of the array.
#
#  Each element in the array represents your maximum jump length at that position.
#
#  Determine if you are able to reach the last index.
#
#  For example:
#  A = [2,3,1,1,4], return true.
#
#  A = [3,2,1,0,4], return false.
#

def reach?(a)
    max_reach = 0
    step = 0
    a.each_with_index{ |jump,i|
        step -= 1
        if (i + jump > max_reach)
            max_reach = i + jump
            step = a[i]
        end    

        return false if step == 0 && i<a.length-1
    }

    return true
end

[[2,3,1,1,4],[3,2,1,0,4],[2,3,1,1,4],[2,4,2,1,0,4]].each{ |x|
    puts "#{x} - #{reach?(x)}"
}
