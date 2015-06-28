using System;

class Program {
    static void Main() {
        long a = 12343543565;
        long b = 15423131234;

        Console.WriteLine(Convert.ToString(a, 2));
        Console.WriteLine(Convert.ToString(b, 2));

        int i = 10;
        int j = 20;

        for (int k = i; k < j; k++) {
            long x = a >> k;
            long mask = 1 << k;
            if ((x & 1) != 0) {
                b |= mask;
            }
        }

        Console.WriteLine(Convert.ToString(b, 2));
    }
}
