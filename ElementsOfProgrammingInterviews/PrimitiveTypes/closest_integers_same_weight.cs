using System;
using System.Linq;
using System.Runtime.InteropServices;

class Program {
    private static uint Next(uint x) {
        for (int i = 1; i < Marshal.SizeOf(x) * 8 - 1; i++) {
            if (((x >> i) & 1) != ((x >> (i + 1)) & 1)) {
                return x ^ (uint)((i << 1)|((i + 1) << 1));
            }
        } 

        return x;
    }

    public static void Main(string[] args) {
        uint x = (uint) new Random().Next(32, int.MaxValue);
        uint y = Next(x);
        Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", x, Convert.ToString(x, 2), Convert.ToString(x, 2).Count(a => a == '1'), 
                                                               y, Convert.ToString(y, 2), Convert.ToString(y, 2).Count(a => a == '1'));
    }
}
