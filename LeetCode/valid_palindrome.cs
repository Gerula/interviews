using System;

class Program {
    static void Main() {
        string[] strings = new string[] {"A man, a plan, a canal: Panama", "race a car"};

        foreach (string s in strings) {
            int low = 0;
            int high = s.Length - 1;

            while (low <= high) {
                while (!Char.IsLetterOrDigit(s[low]) && low <= high) {
                    low++;
                }

                while (!Char.IsLetterOrDigit(s[high]) && low <= high) {
                    high--;
                }

                if (Char.ToUpper(s[low]) != Char.ToUpper(s[high])) {
                    Console.WriteLine("{0} not a palindrome", s);
                    break;
                }

                low++;
                high--;
            }
            
            if (low >= high) {
                Console.WriteLine("{0} is a palindrome", s);
            }
        }
    }
}
