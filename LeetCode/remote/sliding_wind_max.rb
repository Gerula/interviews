# https://leetcode.com/submissions/detail/34530869/

# @param {Integer[]} nums
# @param {Integer} k
# @return {Integer[]}
class Mono_queue
    def initialize
        @queue = []
    end
    
    def enqueue(value)
        count = 0
        while @queue.any? && @queue.last[0] < value
            count += @queue.last[1] + 1
            @queue.pop
        end
        
        @queue.push([value, count])
    end
    
    def max
        return @queue.first[0]
    end
    
    def dequeue
        return if @queue.empty?
        if @queue.first[1] > 0
            @queue.first[1] -= 1
            return
        end
        
        @queue.shift
    end
end

def max_sliding_window(nums, k)
    return [] if nums.empty? # you fucking assholes!
    result = []
    queue = Mono_queue.new
    0.upto(k - 1).each { |x|
        queue.enqueue(nums[x])
    }
    
    result.push(queue.max)
    k.upto(nums.size - 1).each { |x|
        queue.enqueue(nums[x])
        queue.dequeue
        result.push(queue.max)
    }
    
    return result
end
