using System;
using System.Linq;

static class Program {
    static int DigitalRoot(this int x) {
        while (x.ToString().Length != 1) {
            x = x.ToString().Select(a => a - '0').Sum();
        }

        return x;
    }

    static int AddDigits(this int x) {
        if (x == 0) return 0;
        if (x % 9 == 0) return 9;
        return x % 9;
    }

    static void Main() {
        for (int i = 0; i < int.MaxValue / 1000; i++) {
            if (i.DigitalRoot() != i.AddDigits()) {
                throw new Exception("You are dumb");
            }
        }
    }
}

//  https://leetcode.com/submissions/detail/58787808/
public class Solution {
    public int AddDigits(int num) {
        return num % 9 == 0 && num != 0 ? 9 : num % 9;
    }
}
