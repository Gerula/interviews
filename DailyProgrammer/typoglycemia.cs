// https://www.reddit.com/r/dailyprogrammer/comments/3s4nyq/20151109_challenge_240_easy_typoglycemia/
//
// Typoglycemia is a relatively new word given to a purported recent discovery about how people read written text.
// As wikipedia puts it:
//
//     The legend, propagated by email and message boards,
//     purportedly demonstrates that readers can understand
//     the meaning of words in a sentence even when the interior
//     letters of each word are scrambled. As long as all the
//     necessary letters are present, and the first and last
//     letters remain the same, readers appear to have little
//     trouble reading the text.
//

using System;
using System.Text;

static class Program 
{
    static Random rand = new Random();

    static String Translate(this String s)
    {
        var result = new StringBuilder();
        var acc = new StringBuilder();
        foreach (char c in s)
        {
            if (Char.IsLetterOrDigit(c))
            {
                acc.Append(c);
                continue;
            }

            if (acc.Length > 0)
            {
                result.Append(acc.ShuffleAndEmpty());
            }

            result.Append(c);
        }

        return result.ToString();
    }

    static String ShuffleAndEmpty(this StringBuilder s)
    {
        var result = s.ToString();
        if (s.Length < 4)
        {
            s.Length = 0;
            return result;
        }

        for (int i = s.Length - 2; i > 2; i--)
        {
            var target = rand.Next(1, i);
            var c = s[i];
            s[i] = s[target];
            s[target] = c;
        }

        result = s.ToString();
        s.Length = 0;
        return result;
    }

    static void Main()
    {
        var s = @"According to a research team at Cambridge University, it doesn't matter in what order the letters in a word are,
the only important thing is that the first and last letter be in the right place.
The rest can be a total mess and you can still read it without a problem.
This is because the human mind does not read every letter by itself, but the word as a whole.
Such a condition is appropriately called Typoglycemia.";

        Console.WriteLine(s);
        Console.WriteLine(s.Translate());
    }
}
