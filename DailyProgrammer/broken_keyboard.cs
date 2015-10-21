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

    static String FingerPrint(this String word)
    {
        return String.Join(String.Empty, word.Distinct().OrderBy(x => x));
    }

    static void Main()
    {
        var allWords = ReadWords().
                        OrderBy(y => y.Length).
                        Reverse().
                        Select(x => 
                                new 
                                { 
                                    Word = x, 
                                    FingerPrint = x.FingerPrint() 
                                });

        Console.WriteLine(String.Join(Environment.NewLine, allWords.Select(x => String.Format("{0} - {1}", x.Word, x.FingerPrint))));

        new [] {
            "abcd",
            "qwer",
            "hjklo"
        }.ToList().ForEach(x => {
            String fingerPrint = x.FingerPrint();
            Console.WriteLine(fingerPrint);
            Console.WriteLine("{0} - {1}", 
                              x,
                              allWords.
                                  First(word => fingerPrint.IndexOf(word.FingerPrint) >= 0).
                                  Word);
        });
    }
}
