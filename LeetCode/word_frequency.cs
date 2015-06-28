using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        Dictionary<String, int> frequencies = new Dictionary<String, int>(StringComparer.OrdinalIgnoreCase);
        using (StreamReader reader = new StreamReader("word_frequency.cs")) {
            String line;
            while ((line = reader.ReadLine()) != null) {
                string[] words = Regex.Split(line, @"\W|_");
                foreach (string word in words) {
                    if (frequencies.ContainsKey(word)) {
                        frequencies[word]++;
                    } else {
                        frequencies[word] = 1;
                    }
                }
            } 
        }

        Console.WriteLine(String.Join(Environment.NewLine, frequencies.Select(x => String.Format("{0} => {1}", x.Key, x.Value))));
    }
}
