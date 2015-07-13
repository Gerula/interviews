using System;

class Program {
    static void Main() {
        int x = 2;
        int n = 5;
        int pow = n;
        int result = 1;
        while (n > 1) {
            if (n % 2 == 0) {
                result *= x * x;
            } else {
                result *= x * x * x;
            }
            n /= 2;
        }

        Console.WriteLine("{0} ^ {1} = {2}", x, pow, result);
    }
}
