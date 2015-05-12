# Implement an algorithm to find the nth to last element of a singly linked list.

require_relative "linked_list"

list = Linked_list.new(0)
list.fill_with_shit
list.print_list

class Linked_list
    def n_th(n)
        head = self
        tail = self
        1.upto(n) {
            if !tail
                raise("Wth? List is smaller than #{n}")
            end 
            tail = tail.link
        }

        while tail
            head = head.link
            tail = tail.link
        end

        return head
    end
end

puts list.n_th(3).inspect
