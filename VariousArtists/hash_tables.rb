# Once I was asked to do this in an interview. Very open-ended, did it in C# with chaining. 
# I want to do it here both with chaining and with double hashing (probing) in Ruby
#

class Chaining_hash
    def initialize(size, &hash)
        @data = []
        @size = size
        @hash = hash
    end

    def [](y)
        bucket = @data[index(y)] 
        return bucket.find{|x|
            x[0] == y
        }[1] unless bucket.nil? || !bucket.any?
     
        return nil
    end

    def index(value)
        @hash.call(value) % @size
    end

    private :index

    def []=(y, value)
        @data[index(y)] ||= []
        @data[index(y)].push([y,value])
    end
end

puts "---- Chaining ----"

hash = Chaining_hash.new(100) { |x|
    x.hash
}

hash[:stuff] = "more_stuff"
hash[:stufff] = "less_stuff"

puts hash[:stuff]
puts hash[:stufff]

puts hash.inspect

puts "---- Double hashing ----"

class Double_hash
    def initialize(size, hash_1, hash_2)
        @size = size
        @count = 0
        @data = Array.new(size)
        @hash_1 = hash_1
        @hash_2 = hash_2
    end

    def [](value)
        it = index(value)
        return @data[it][1] unless @data[it].nil?
        return nil
    end

    def []=(idx, value)
        if @count == @size
            raise("Hash table is full")
        end

        @count += 1
        @data[index(idx)] = [idx, value]
    end

    def index(value)
        it = 0
        while !@data[it].nil? && @data[it][0] != value
            it = next_index(it, value)
        end

        return it
    end

    def next_index(index, value)
        (@hash_1.call(value) + index * @hash_2.call(value)) % @size
    end

    private :index, :next_index
end

first_hash = lambda {|x|
    x.hash
}

second_hash = lambda {|x|
    x.hash ^ 997
}

hash = Double_hash.new(20, first_hash, second_hash)
hash[:garbage] = "stuff"
hash[:garbage2] = "more stuff"
puts hash[:garbage]
puts hash[:garbage2]
puts hash.inspect

