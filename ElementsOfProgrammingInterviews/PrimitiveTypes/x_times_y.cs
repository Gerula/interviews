// Multiply x and y without using sum or prod.
// Only bitwise stuff is allowed. Because fuck you, that's why.

//
// 10 = 0 1 0 1 0
// 3  = 0 0 0 1 1
// 30 = 1 1 1 1 0
//
//
//

using System;

class Program {
    static int multiply(int x, int y) {
         int sum = 0;
         while (y != 0) {
            if ((y & 1) != 0) {
                sum = add(sum, x);
            }
            x <<= 1; 
            y >>= 1;
         }

         return sum;
    }

    static int add(int x, int y) {
        while (y != 0) {
            int carry = x & y;
            x ^= y;
            y = carry << 1;
        }

        return x;
    }

    static void Main() {
        int x = 11;
        int y = 3;
        Console.WriteLine("{0} x {1} = {2}", x, y, multiply(x, y));
    }
}
