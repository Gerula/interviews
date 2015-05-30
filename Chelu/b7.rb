# Design an LRU cache. 
#

class Page < Struct.new(:val)
end

class QueueNode < Struct.new(:page, :prev, :next)
    def inspect
        "#{page}"
    end
end

class CacheQueue
   def initialize(max)
      @head = nil
      @tail = nil
      @count = 0
      @max = max
   end

   def put(page)
      new_page = QueueNode.new(page, @tail, nil)
      if @head.nil? && @tail.nil?
        @head = new_page
        @tail = new_page
      elsif @count < @max    
        @tail.next = new_page
      else 
        puts "Cache is full, need to scrap the least used"
        new_page.prev = @tail.prev
        @tail.prev.next = new_page
      end
      @count += 1
      @tail = new_page
      return new_page
   end 

   def move_to_front(node)
       return if @head == node
       if @tail == node
            @tail = node.prev
       end
       node.prev.next = node.next
       node.next.prev = node.prev unless node.next.nil?
       @head.prev = node
       node.next = @head
       @head = node
   end

   def inspect
      s = ""
      current = @head
      while !current.nil?
        s<<"[#{current.page}]"
        current = current.next
      end
      s
   end
end

class Cache
    def initialize(max)
        @addresses = {}
        @queue = CacheQueue.new(max)
    end
    
    def get_data(page)
        page * 3
    end

    def get(page)
        puts "request #{page}"
        @addresses[page] ||= @queue.put(get_data(page))
        @queue.move_to_front(@addresses[page])
    end
end

cache = Cache.new(5)
cache.get("x")
puts cache.inspect
cache.get("y")
puts cache.inspect
cache.get("z")
puts cache.inspect
cache.get("w")
puts cache.inspect
cache.get("t")
puts cache.inspect
cache.get("x")
puts cache.inspect
cache.get("t")
puts cache.inspect
cache.get("x")
puts cache.inspect
cache.get("1")
puts cache.inspect

