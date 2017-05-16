//  https://leetcode.com/problems/integer-replacement/
//  https://leetcode.com/submissions/detail/83557270/
//
//
//  Submission Details
//  47 / 47 test cases passed.
//      Status: Accepted
//      Runtime: 42 ms
//          Submitted: 1 minute ago

public class Solution {
    //   9 - 8 - 4 - 2 - 1
    //   9 - 10 - 5 - 4 - 2 - 1
    //   9 - 10 - 5 - 6 - 3 - 
    public int IntegerReplacement(int n) {
        if (n < 2) {
            return 0;
        }

        if (n == 3) {
            return 2;
        }

        if ((n & 1) == 0 || n == int.MaxValue) {
            return 1 + IntegerReplacement(n / 2);
        }

        if (GetLength(n - 1) < GetLength(n + 1)) {
            return 1 + IntegerReplacement(n - 1);
        }

        return 1 + IntegerReplacement(n + 1);
    }

    public int GetLength(int n) {
        var setBits = 0;
        while (n != 0) {
            setBits++; n &= n - 1;
        }

        return setBits;
    }
}

//  https://leetcode.com/submissions/detail/83565020/
//
//  Submission Details
//  47 / 47 test cases passed.
//      Status: Accepted
//      Runtime: 49 ms
//          Submitted: 8 hours, 5 minutes ago

public class Solution {
    public int IntegerReplacement(int n, Dictionary<int, int> cache = null) {
        if (cache == null) {
            cache = new Dictionary<int, int>();
        }

        if (cache.ContainsKey(n)) {
            return cache[n];
        }

        if (n < 2) {
            cache[n] = 0;
            return cache[n];
        }

        if (n == int.MaxValue || (n & 1) == 0) {
            cache[n] = 1 + IntegerReplacement(n / 2, cache);
            return cache[n];
        }

        cache[n] = 1 + Math.Min(IntegerReplacement(n - 1, cache), IntegerReplacement(n + 1, cache));
        return cache[n];
    }
}
