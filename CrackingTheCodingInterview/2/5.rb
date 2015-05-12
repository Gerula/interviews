# Given a circular linked list, implement an algorithm which returns node at the begin- ning of the loop.
#

require_relative "linked_list"

list = Linked_list.new(0)
list.fill_with_shit
list.print_list
list.make_cycle(3)

fast = list.head
slow = list.head

while fast && fast.link && slow
    slow = slow.link
    fast = fast.link.link
    if fast == slow
        break
    end
end

if fast != slow
    puts "No cycle. Yay!"
    exit
end

slow = list.head
count = 0
while slow != fast
    count+=1
    slow = slow.link
    fast = fast.link
end

puts "Detected cycle at #{count + 1}nth node with value #{slow.val}" 


