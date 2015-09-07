using System;
using System.Collections.Generic;

// https://leetcode.com/submissions/detail/39112846/
//
// Submission Details
// 21 / 21 test cases passed.
//  Status: Accepted
//  Runtime: 72 ms
//
class Program {
    private int count = 0;
    private readonly int badVersion;
    private Dictionary<int, bool> cache = new Dictionary<int, bool>();

    public Program(int badVer) {
        badVersion = badVer;
    }

    private bool IsBadVersion(int version) {
        count++;
        if (version >= badVersion) {
            return true;
        }

        return false;
    }

    private bool CachedBadVersion(int version) {
        if (!cache.ContainsKey(version)) {
            cache[version] = IsBadVersion(version);
        }

        return cache[version];
    }

    public int FirstBadVersion(int n) {
        int low = 1;
        int high = n;
        if (low == 1 && CachedBadVersion(low)) {
            return 1;
        }

        while (low < high) {
            int mid = low + (high - low) / 2;
            if (!CachedBadVersion(mid) &&
                mid < n &&
                CachedBadVersion(mid + 1)) {
                return mid + 1;
            }
            
            if (CachedBadVersion(mid)) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }

        return -1;
    }

    public int GetCount() {
        return count;
    }

    static void Main() {
        Program p = new Program(5);
        Console.WriteLine("{0} - {1}", p.FirstBadVersion(101), p.GetCount());
        p = new Program(1);
        Console.WriteLine("{0} - {1}", p.FirstBadVersion(1), p.GetCount());
        p = new Program(10);
        Console.WriteLine("{0} - {1}", p.FirstBadVersion(9), p.GetCount());
    }
}
