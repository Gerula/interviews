using System;

class Program {
    private enum Colors {
            red = 0,
            white,
            blue
    }

    static void Flag(Colors[] c) {
        int beginning = -1;
        int end = c.Length;
        int middle = 0;
        while (middle < end) {
            switch (c[middle]) {
                case Colors.red:
                    beginning++;
                    Swap(ref c[beginning], ref c[middle]);
                    middle++;
                    break;
                case Colors.white:
                    middle++;
                    break;
                case Colors.blue:
                    end--;
                    Swap(ref c[middle], ref c[end]);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }

    static void Swap(ref Colors a, ref Colors b) {
        Colors c = a;
        a = b;
        b = c;
    }

    static void Main() {
        int n = 15;
        Colors[] colors = new Colors[n];
        Random rand = new Random();
        for (int i = 0; i < n; i++) {
            colors[i] = (Colors) rand.Next(0, 3);
        }

        Console.WriteLine(String.Join(", ", colors));
        Flag(colors);
        Console.WriteLine(String.Join(", ", colors));
    }
}
