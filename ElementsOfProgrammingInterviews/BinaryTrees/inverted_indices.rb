# Let A be an array of numbers. The pair i,j is said to be inverted if i < j and a[i] > a[j].
# Return the number of inverted pairs of indices.
#

def merge_sort(array, low, high)
    return 0 if low >= high
    mid = low + (high - low) / 2
    return merge_sort(array, low, mid) + merge_sort(array, mid + 1, high) + merge(array, low, mid, high) 
end

def merge(a, low, mid, high)
    k = 0
    m = []
    count = 0
    middle = mid - 1
    while low <= middle && mid < high
        if a[low] < a[mid] 
            m[k] = a[low]
            low += 1
        else
            m[k] = a[mid]
            mid += 1
            count += 1
        end
        k += 1
    end

    while low <= middle
        m[k] = a[low]
        k += 1
        low += 1
    end

    while mid < high
        m[k] = a[mid]
        k += 1
        mid += 1
    end
    puts m.inspect
    0.upto(k - 1).each { |i|
        a[high] = m[i]
        high -= 1
    }
    
    return count
end

array = 0.upto(9).map { Random.rand(1..10) }
puts array.inspect
puts merge_sort(array, 0, array.size - 1)
puts array.inspect
