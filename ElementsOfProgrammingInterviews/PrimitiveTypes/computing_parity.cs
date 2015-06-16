// How would you go about computing the parity of a very large number?
//

using System;
using System.Linq;

class Program {
    static byte parity(byte i) {
        byte result = 0;
        while (i > 0) {
            i &= (byte)(i - 1);
            result ^= 1; 
        }
        return result;
    }

    static byte parity(long i) {
        byte result = 0;
        for (int j = 24; j >= 0; j-=8) {
            result ^= parity((byte)((i >> j) & (byte)255));
        }
        
        return result;
    }

    public static void Main(string[] args) {
        uint x = uint.MaxValue;
        Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", x, Convert.ToString(x, 2), Convert.ToString(x, 2).Count(a => a == '1'), parity(x)));
        x -= 1;
        Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", x, Convert.ToString(x, 2), Convert.ToString(x, 2).Count(a => a == '1'), parity(x)));
    }
}
