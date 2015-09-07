using System;
using System.Collections.Generic;

class Program {
    private int count = 0;
    private Dictionary<int, bool> cache = new Dictionary<int, bool>();

    private bool IsBadVersion(int version) {
        count++;
        if (version > 5) {
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
        int low = 0;
        int high = n;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (!CachedBadVersion(mid) &&
                mid < n &&
                CachedBadVersion(mid + 1)) {
                return mid;
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
        Program p = new Program();
        Console.WriteLine(p.FirstBadVersion(100));
        Console.WriteLine(p.GetCount());
    }
}
