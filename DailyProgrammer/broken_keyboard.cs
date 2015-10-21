// Help! My keyboard is broken, only a few keys work any more. If I tell you what keys work, can you tell me what words I can write?
//
// You'll be given a line with a single integer on it, telling you how many lines to read. Then you'll be given that many lines, each line a list of letters representing the keys that work on my keyboard. Example:
//
// 3
// abcd
// qwer
// hjklo
//
// Your program should emit the longest valid English language word you can make for each keyboard configuration.
//
// abcd = bacaba
// qwer = ewerer
// hjklo = kolokolo
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Program
{
    static readonly String WordsFile = "/usr/share/dict/words";

    static IEnumerable<String> ReadWords()
    {
        using (StreamReader reader = new StreamReader(WordsFile))
        {
            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    static bool BuiltWith(this String word, String letters)
    {
        return !word.Any(x => !letters.Contains(x));
    }

    static void Main()
    {
        var allWords = ReadWords().
                        OrderBy(y => y.Length).
                        Reverse();

        new [] {
            "abcd",
            "qwer",
            "hjklo"
        }.ToList().ForEach(x => {
            Console.WriteLine("{0} - {1}", 
                              x,
                              allWords.
                                First(word => word.BuiltWith(x)));
        });
    }
}
