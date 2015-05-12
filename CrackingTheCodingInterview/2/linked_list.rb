class Linked_list
    def initialize(val = nil, link = nil)
        @val = val
        @link = link
    end

    def fill_with_shit
        size = Random.rand(15)
        head = self
        1.upto(size).each {|i|
            head.link = Linked_list.new(Random.rand(15))
            head = head.link
        }
    end

    def print_list
        head = self
        while head
            print "#{head.val} "
            head = head.link
        end
        puts
    end

    attr_accessor :val
    attr_accessor :link
end

