
class LRUCache
    class Node < Struct.new(:key, :val, :prev, :next)
    end

    class Node < Struct.new(:key, :val, :prev, :next)
    end
    
    # Initialize your data structure here
    # @param {Integer} capacity
    def initialize(capacity)
        @head = Node.new(:head)
        @tail = Node.new(:tail)
        @head.next, @tail.prev = @tail, @head
        @hash = {}
        @capacity = capacity
    end

    # @param {Integer} key
    # @return {Integer}
    def get(key)
        return -1 if @hash[key].nil?
        node = @hash[key]
        node.next.prev = node.prev
        node.prev.next = node.next
        node.prev = @head
        node.next = @head.next
        @head.next.prev = node
        @head.next = node
        return node.val
    end

    # @param {Integer} key
    # @param {Integer} value
    # @return {Void}
    def set(key, value)
        if @capacity == 0 && @hash[key].nil?
            target = @tail.prev
            target.prev.next = target.next
            target.next.prev = target.prev
            @hash[target.key] = nil
        else
            @capacity -= 1
        end

        node = @hash[key] || Node.new(key, value)
        node.key, node.val = key, value
        node.next = @head.next
        node.next.prev = node
        node.prev = @head
        @head.next = node
        @hash[key] = node
    end
end

cache = LRUCache.new(1)
cache.set(2, 1)
puts cache.get(2)
cache.print
cache.set(3, 2)
puts cache.get(2)
puts cache.get(3)
