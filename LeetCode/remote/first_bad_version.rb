#   https://leetcode.com/problems/first-bad-version/
#
#   You are a product manager and currently leading a team to develop a new product.
#   Unfortunately, the latest version of your product fails the quality check.
#   Since each version is developed based on the previous version, all the versions after a bad version are also bad. 

#   
#   Submission Details
#   21 / 21 test cases passed.
#       Status: Accepted
#       Runtime: 64 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53263348/

def first_bad_version(n)
    low = 1
    high = n
    while low <= high
        mid = low + (high - low) / 2
        if is_bad_version(mid)
            high = mid - 1
        else
            low = mid + 1
        end
    end
    
    return low
end

def first_bad_version(n)
    low, high = 1, n
    while low < high
        mid = low + ((high - low) >> 2)
        if is_bad_version(mid)
           high = mid 
       else
           low = mid + 1
       end
    end
    
    low
end
