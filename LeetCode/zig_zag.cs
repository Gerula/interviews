using System;
using System.Text;

// Testing windows setup
// Kekekeke
// P   A   H   N
// A P L S I I G
// Y   I   R
//
// P     I     N
// A   L S   I G
// Y A   H R
// P     i

static class Program {
    static void ZigZag(this String s, int levels) {
        int step = 2 * levels - 2;
        StringBuilder sb = new StringBuilder();
        for (int level = 0; level < levels; level++) {
            if (level == 0 || level == levels - 1) {
                for (int j = level; j < s.Length; j += step) {
                    sb.Append(s[j]);
                }
            } else {
                int j = level;
                bool flag = true;
                int step1 = 2 * (levels - level - 1);
                int step2 = step - step1;
                while (j < s.Length) {
                    sb.Append(s[j]);
                    j += flag ? step1 : step2;
                    flag = !flag;
                }
            }
        }

        Console.WriteLine(sb.ToString());
    }

    static void Main() {
        String s = "PAYPALISHIRING";
        s.ZigZag(3);
        Console.WriteLine();
        s.ZigZag(4);
    }
}
