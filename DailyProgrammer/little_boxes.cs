// https://www.reddit.com/r/dailyprogrammer/comments/3pnd3t/20151021_challenge_237_intermediate_heighmap_of/
//
// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

static class Program
{
    enum State 
    {
        Undecided,
        Open,
        Closed
    }

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
        List<State> stateCache = null;
        using (StreamReader reader = new StreamReader(path))
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line.Process(ref stateCache));
            }
        }

        Console.WriteLine();
    }

    static String Process(this String line, ref List<State> stateCache)
    {
        if (stateCache == null)
        {
            stateCache = Enumerable.Repeat(State.Undecided, line.Length).ToList();
        }

        StringBuilder sb = new StringBuilder();
        int level = -1;
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c != ' ')
            {
                sb.Append(c);
                if (c == '+' && i > 1 && line[i - 1] == '-')
                {
                    stateCache[i] = State.Closed;
                }

                if (c == '+' && i < line.Length - 1 && line[i + 1] == '-')
                {
                    stateCache[i] = State.Open;
                }

                if (c == '|') 
                {
                    level += stateCache[i] == State.Open ? 1 : -1;
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
