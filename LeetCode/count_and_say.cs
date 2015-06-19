using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program {

    static String CountAndSay(int n) {
        return String.Join(String.Empty,
               Enumerable.Repeat(1, n - 1).Aggregate("1", (a, b) => {
                                            StringBuilder result = new StringBuilder();
                                            char current = a[0];
                                            int count = 1;
                                            for (int i = 1; i < a.Length; i++) {
                                                if (a[i] == current) {
                                                    count++;
                                                } else {
                                                    result.Append(String.Format("{0}{1}", count, current));
                                                    count = 1;
                                                    current = a[i];
                                                }
                                            }

                                            result.Append(String.Format("{0}{1}", count, current));
                                            return result.ToString();
                                      }
               ));
    }

    static void Main() {
        Console.WriteLine(CountAndSay(2));
    }
}
