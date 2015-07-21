using System;
class Program {
    static void Main() {
        String[] s = new String[] {
            "using System;",
            "class Program {",
            "   static void Main() {",
            "       String[] s = new String[] {",
            "       }\"",
            "       for (int i = 0; i < 4; i++) {",
            "            Console.WriteLine(s[i]);",
            "       }",
            "",
            "       for (int i = 0; i < s.Length; i++) {",
            "           Console.WriteLine(\"\\\"\"+s[i] + \"\\\"\");",
            "       }",
            "",
            "       for (int i = 4; i < s.Length; i++) {",
            "           Console.WriteLine(s[i]);",
            "       }",
            "   }",
            "}"
        };

        for (int i = 0; i < 4; i++) {
            Console.WriteLine(s[i]);
        }

        for (int i = 0; i < s.Length; i++) {
            Console.WriteLine("\"" + s[i] + "\"");
        }

        for (int i = 4; i < s.Length; i++) {
            Console.WriteLine(s[i]);
        }
    }
}
