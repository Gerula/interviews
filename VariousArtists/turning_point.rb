# You get an array of words. Sorted. But some idiot shifted the array. Find out where is the shift point.
# It's very importat if the elementes are distinct.
#
# A friend of mine got this question at a facebook phone screen. He fucked it up but still got onsite where he got the opportunity to fuck it up completely.
#

array = ["h", "i", "j", "k", "l", "m", "n", "n", "o", "p", "a", "a", "a", "b", "c", "d", "e"]

def find_turning_point(a, left, right)
    if (left >= right)
        return right
    end

    middle = left + (right - left) / 2

    if (a[left] > a[middle])
        return find_turning_point(a, left, middle - 1)
    end

    if (a[middle] > a[left])
        return find_turning_point(a, middle + 1, right)
    end

    return 0
end

puts array[find_turning_point(array, 0, array.length - 1)]
