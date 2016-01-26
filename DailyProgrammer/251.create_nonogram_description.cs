//  https://www.reddit.com/r/dailyprogrammer/comments/42lhem/20160125_challenge_251_easy_create_nonogram/
//
//  Today you will recieve an image in ASCII with ' ' being empty and '*' being full.
//  The number of rows and columns will always be a multiple of 5.
//
//  Give the columns and rows for the input 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

static class Program
{
    private static Regex Stars = new Regex(@"\*+", RegexOptions.Compiled);

    static IList<String> ReadNonogram(this String file)
    {
        return File.ReadLines(file).ToList();
    }

    static IEnumerable<String> Describe(this IList<String> nonogram)
    {
        var lines = nonogram.Select(x => x.ReadConfiguration()).ToList();
        var lineLength = nonogram.First().Length;
        var columns = Enumerable
                      .Range(0, lineLength)
                      .Select(x => new String(nonogram
                                              .Select(y => y[x])
                                              .ToArray())
                                       .ReadConfiguration())
                      .ToList();

        var blockLength = Math.Max(
                lines.Select(x => x.Select(y => y.Length).Max()).Max(),
                columns.Select(x => x.Select(y => y.Length).Max()).Max()
                + 1);

        var emptyBlock = new String(
                Enumerable
                .Repeat(' ', blockLength)
                .ToArray());
        var maxLines = lines.Select(x => x.Count).Max();
        var maxColumns = columns.Select(x => x.Count).Max();
        lines = lines.Pad(maxLines);
        columns = columns.Pad(maxColumns);

        var emptyPadding = String.Join(
                String.Empty,
                Enumerable
                .Repeat(emptyBlock, maxLines));

        return Enumerable
               .Range(0, maxColumns)
               .Select(x => String
                       .Format(
                           "{0}{1}", 
                           emptyPadding,
                           String
                           .Join(
                               String.Empty,
                               columns
                               .Select(y => y[x].PadLeft(blockLength))
                           )   
                       ))
               .Concat(
                   Enumerable
                   .Range(0, nonogram.Count)
                   .Select(x => 
                       String
                       .Format(
                           "{0}{1}",
                           String.Join(
                               String.Empty, 
                               lines[x]
                               .Select(y => y.PadLeft(blockLength))),
                           String.Join(
                               String.Empty, 
                               nonogram[x]
                               .Select(y => y.ToString().PadLeft(blockLength))))));
    }

    static List<IList<String>> Pad(this List<IList<String>> list, int length)
    {
        return list
               .Select(x => {
                        if (x.Count == length)
                        {
                            return x;
                        }

                        return Enumerable
                               .Repeat(String.Empty, length - x.Count)
                               .Concat(x)
                               .ToList();
                       })
               .ToList();
    }

    static IList<String> ReadConfiguration(this String s)
    {
        return Stars
               .Matches(s)
               .Cast<Match>()
               .Select(x => x.Length.ToString())
               .ToList();
    }

    static void Main()
    {
        for (var i = 1; i < 4; i++)
        {
            Console.WriteLine(String.Join(
                        Environment.NewLine,
                        String.Format("251.{0}.in", i)
                        .ReadNonogram()
                        .Describe()));
        }
    }
}
