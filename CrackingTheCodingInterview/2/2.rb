require_relative "linked_list"

list = Linked_list.new(0)
list.fill_with_shit
list.print_list

class Linked_list
    def contains?(element)
       iterator = self
       while iterator != element
           if iterator.val == element.val
               return true
           end
           iterator = iterator.link
       end

       return false
    end

    def duplicates_be_gone
        iterator = self
        while iterator && iterator.link
            if contains?(iterator.link) 
                iterator.link = iterator.link.link
                puts "Deleted element #{iterator.val}"
            end

            iterator = iterator.link
        end
    end
end

list.duplicates_be_gone
list.print_list
