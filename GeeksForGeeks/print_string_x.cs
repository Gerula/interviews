using System;
using System.Linq;
using System.Text;
using System.Threading;

static class Program {
    static void DelayPrint(object s) {
        Thread.Sleep(50);
        Console.Write(s.ToString());
    }

    static void Print(int low, int high, String s) {
        for (int i = 0; i < low; i++) {
            DelayPrint("  ");
        }
        
        DelayPrint(s[low]);
        for (int i = low; i < high - 1; i++) {
            DelayPrint("  ");
        }
        
        DelayPrint(" ");
        DelayPrint(s[high]);
        
        for (int i = high; i < s.Length; i++) {
            DelayPrint("  ");
        }
    }

    static void GetX(this String s) {
        int low = 0;
        int high = s.Length - 1;
        while (low < s.Length && high >= 0) {
            if (low < high) {
                Print(low, high, s);
            } else if (low == high) {
                for (int i = 0; i < low; i++) {
                    DelayPrint("  ");
                }

                DelayPrint(s[low]);

                for (int i = 0; i < low; i++) {
                    DelayPrint("  ");
                }
            } else {
                Print(high, low, s);
            }

            low++;
            high--;
            Console.WriteLine();
        }
    }

    static void Main() {
        String s = "12345";
        s.GetX();
        s = "geeksforgeeks";
        s.GetX();
    }
}
