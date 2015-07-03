using System;

class Program {
    static void Main() {
        int a = 2;
        int b = 3;
        int y;
        int x;

        for (int i = 0; i <= 1; i++)
        {
            x = i;
            y = (1 - x) * a + x * b; 
            Console.WriteLine("x={0} y={1} a={2} b={3}", x, y, a, b);
        }
    }
}
