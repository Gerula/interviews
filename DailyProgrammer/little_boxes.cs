// https://www.reddit.com/r/dailyprogrammer/comments/3pnd3t/20151021_challenge_237_intermediate_heighmap_of/
//
// 

using System;
using System.IO;
using System.Linq;
using System.Text;

static class Program
{
    static char Char(this int level)
    {
        switch (level)
        {
            case 0: return '#';
            case 1: return '=';
            case 2: return '-';
            case 3: return '.';
            default: return ' ';
        }
    }

    static void Print(String path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line.Process());
            }
        }

        Console.WriteLine();
    }

    static String Process(this String line)
    {
        StringBuilder sb = new StringBuilder();
        int level = -1;
        int borderCount = line.Count(x => x == '|');
        int borderLimit = borderCount / 2;
        foreach(char c in line)
        {
            if (c != ' ')
            {
                sb.Append(c);
                if (c == '|') 
                {
                    level += (borderCount-- > borderLimit) ? 1 : -1;
                }
            }
            else
            {
                sb.Append(level.Char());
            }
        }

        return sb.ToString();
    }

    static void Main()
    {
        Print("boxes.in");
        Print("boxes.in2");
    }
}
