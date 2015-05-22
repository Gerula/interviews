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

hash = Chaining_hash.new(100) { |x|
    x.hash
}

hash[:stuff] = "more_stuff"
hash[:stufff] = "less_stuff"

puts hash[:stuff]
puts hash[:stufff]

puts hash.inspect
