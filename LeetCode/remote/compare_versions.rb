#   https://leetcode.com/problems/compare-version-numbers/
#
#   Compare two version numbers version1 and version2.
#   If version1 > version2 return 1, if version1 < version2 return -1, otherwise return 0.
#
#   You may assume that the version strings are non-empty and contain only digits and the . character.

#   https://leetcode.com/submissions/detail/53212474/
#
#
#   Submission Details
#   71 / 71 test cases passed.
#       Status: Accepted
#       Runtime: 80 ms
#           
#           Submitted: 0 minutes ago
#

# @param {String} version1
# @param {String} version2
# @return {Integer}
def compare_version(version1, version2)
    version1 = version1.split('.').map { |x| x.to_i }
    version2 = version2.split('.').map { |x| x.to_i }
    max = [version1.size, version2.size].max
    for i in 0...max
        cmp = (i < version1.size ? version1[i] : 0) <=> (i < version2.size ? version2[i] : 0)
        return cmp if cmp != 0
    end
    
    return 0
end


