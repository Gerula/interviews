//  https://leetcode.com/submissions/detail/67910775/
class Solution {
public:
    bool isUgly(int num) {
        if (num < 2) {
            return num == 1;
        }

        for (const int &i : {2, 3, 5} )  {
            if (num % i == 0) {
                return isUgly(num / i);
            }
        }
        
        return false;
    }
};
