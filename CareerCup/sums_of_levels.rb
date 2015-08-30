require 'test/unit'
extend Test::Unit::Assertions

class Node < Struct.new(:value, :left, :right)
end

def sum_levels(levels, level, current)
    levels[level] ||= 0
    levels[level] += current.value
    sum_levels(levels, level + 1, current.left) unless current.left.nil?
    sum_levels(levels, level + 1, current.right) unless current.right.nil?
end

tree = Node.new(1,
                Node.new(2,
                         Node.new(3),
                         Node.new(4)),
                Node.new(5,
                         Node.new(6),
                         Node.new(7)))

levels = {}
sum_levels(levels, 0, tree)

assert_equal(1,  levels[0])
assert_equal(7,  levels[1])
assert_equal(20, levels[2])

