#     Follow up for "Find Minimum in Rotated Sorted Array":
#         What if duplicates are allowed?
#
#             Would this affect the run-time complexity? How and why?
#
#             Suppose a sorted array is rotated at some pivot unknown to you beforehand.
#
#             (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
#
#             Find the minimum element.
#
#             The array may contain duplicates.
#

class Array
    def find_min
    end

end

[[4, 4, 5, 1, 2, 2, 2, 3, 4], [1, 2, 3, 4, 5], [5, 6, 3, 3, 3, 4]].each { |x|
    puts "min(#{x.inspect}) == #{x.find_min}"
}
