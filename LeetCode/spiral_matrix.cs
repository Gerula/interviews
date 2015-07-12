using System;

class Program {
    static void Main() {
        int n = 3;
        int start = 1;
        int[,] a = new int[n,n];

        for (int idx = 0; idx < n / 2; idx++) {
            for (int i = idx; i < n - idx; i++) {
                a[idx, i] = start++;    
            }    

            for (int i = idx + 1; i < n - idx - 1; i++) {
                a[i, n - idx - 1] = start++;
            }

            for (int i = n - idx - 1; i >= idx; i--) {
                a[n - idx - 1, i] = start++;    
            }

            for (int i = n - idx - 2; i > idx; i--) {
                a[i, idx] = start++;
            }
        }

        if (n % 2 == 1) {
            a[n / 2, n / 2] = start;
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write("{0} ", a[i, j]);
            }

            Console.WriteLine();
        }
    }
}
