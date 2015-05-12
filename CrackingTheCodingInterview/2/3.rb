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

    def delete_nth(n)
        nth_minus_1 = n_th(n - 1)
        nth_minus_1.link = nth_minus_1.link.link
    end
end

puts list.n_th(3).inspect
list.delete_nth(2+3)
list.print_list
