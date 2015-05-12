#  You have two numbers represented by a linked list, where each node contains a sin- gle digit. The digits are stored in reverse order, such that the 1’s digit is at the head of the list. Write a function that adds the two numbers and returns the sum as a linked list.
#  EXAMPLE
#  Input: (3 -> 1 -> 5) + (5 -> 9 -> 2)
#  Output: 8 -> 0 -> 8
#

require_relative "linked_list"

list_1 = Linked_list.new(1)
list_2 = Linked_list.new(1)
list_1.fill_with_shit
list_2.fill_with_shit
list_3 = nil
list_1.print_list
list_2.print_list

list_1 = list_1.head
list_2 = list_2.head

carry = 0
while list_1 || list_2
    sum = ((list_1)? list_1.val : 0) + 
          ((list_2)? list_2.val : 0) + carry
    if sum > 10
        carry = sum % 10
        sum = sum / 10
    else
        carry = 0
    end 
    
    if list_1
       list_1 = list_1.link
    end

    if list_2
       list_2 = list_2.link
    end

    if !list_3
        list_3 = Linked_list.new(sum)
    else
        new = Entry.new(sum)
        new.link = list_3.head
        list_3.head = new
    end
end

list_3.reverse
list_3.print_list
