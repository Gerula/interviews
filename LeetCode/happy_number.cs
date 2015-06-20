using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static bool IsHappy(long i) {
        HashSet<long> loop = new HashSet<long>();
        while (i != 1) {
            if (loop.Contains(i)) {
                return false;
            }

            loop.Add(i);
            i = i.ToString().Select(x => (x - '0') * (x - '0')).Aggregate(0, (a, b) => a + b);
        }
        
        return true;
    }

    static void Main() {
        Enumerable.Range(1, 100).ToList().ForEach(x => Console.WriteLine("{0} - {1},", x, IsHappy(x)));
    }
}
