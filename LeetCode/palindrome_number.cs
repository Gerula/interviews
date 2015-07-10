using System;
using System.Linq;

static class Program {
    static bool Palindrome(this int n) {
        int m = n;
        int div = 1;
        while (m > 10) {
            div *= 10;
            m /= 10;
        }

        while (n != 0) {
            int high = n / div;
            int low = n % 10;
            if (high != low) {
                return false;
            }

            n = n % div / 10;
            div /= 100;
        }

        return true;
    }

    static void Main() {
        Console.WriteLine(String.Join(", ", Enumerable.Range(1000, 20000).Where(x => x.Palindrome())));
    }
}
