using System;

class Program {
    static byte reverse(byte x) {
        int y = 0;
        while (x != 0) {
            y = (y << 1) | (x & 1);
            x >>= 1;
        }

        return (byte) y;
    }    

    public static void Main(string[] args) {
        byte x = (byte) new Random().Next(10, 255);
        byte y = reverse(x);
        Console.WriteLine("{0} - {1} - {2} - {3}", x, Convert.ToString(x, 2), y, Convert.ToString(y, 2));
    }
}
