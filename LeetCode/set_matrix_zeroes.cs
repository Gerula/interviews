using System;

class Program {
    static void Print(int[,] a, int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write("{0} ", a[i,j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main() {
        int n = 30;
        int[,] a = new int[n, n];
        Random rand = new Random();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                a[i,j] = rand.Next(1,10);
                if (rand.Next(1, 1000) % 200 == 0) {
                    a[i,j] = 0;
                }
            }
        }
        
        Print(a, n);

        bool columnZero = false;
        bool lineZero = false;
        for (int i = 0; i < n; i++ ) {
            if (a[i,0] == 0) {
                columnZero = true;
            }
            if (a[0,i] == 0) {
                lineZero = true;
            }
        }

        for (int i = 1; i < n; i++) {
            for (int j = 1; j < n; j++) {
                if (a[i,j] == 0) {
                    a[i,0] = 0;
                    a[0,j] = 0;
                }
            }
        }

        for (int i = 0; i < n; i++) {
            if (a[i,0] == 0) {
                for (int j = 1; j < n; j++) {
                    a[i, j] = 0;
                }
            }
            if (a[0,i] == 0) {
                for (int j = 1; j < n; j++) {
                    a[j, i] = 0;
                }
            }
        }

        if (columnZero) {
            for (int i = 0; i < n; i++) {
                a[i, 0] = 0;
            }
        }

        if (lineZero) {
            for (int i = 0; i < n; i++) {
                a[0, i] = 0;
            }
        }
        
        Print(a, n);
    }
}
