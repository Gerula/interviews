#  Given an unsorted integer array, find the first missing positive integer.
#
#  For example,
#  Given [1,2,0] return 3,
#  and [3,4,-1,1] return 2. 
#

def first_missing_positive(nums)
    i = 0
    while i < nums.size 
        if nums[i] != i + 1 && nums[i] > 0 && nums[i] <=nums.size && nums[i] != nums[nums[i] - 1]
            aux = nums[i]            
            nums[i] = nums[aux - 1]
            nums[aux - 1] = aux
        else
            i += 1
        end
    end

    for i in (0..nums.size - 1)
        if nums[i] != i + 1
            return i + 1
        end
    end    
 
    return nums.size + 1 
end

[[2], [2, 2], [3,2], [0, 1, 2], [1, 2, 0], [3, 4, -1, 1]].each { |x|
    puts first_missing_positive(x)
}

