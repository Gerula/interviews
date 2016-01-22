//  https://en.wikipedia.org/wiki/Farey_sequence
//
//  This sequence twiddles my diddle.

using System;
using System.Collections.Generic;

static class Program
{
    class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override String ToString()
        {
            return String.Format("{0}/{1}", Numerator, Denominator);
        }
    }

    static IEnumerable<Fraction> Farey(this int n)
    {
        var set = new SortedSet<Fraction>(
                    Comparer<Fraction>.Create((a, b) => 
                        ((double) a.Numerator / a.Denominator)
                        .CompareTo((double) b.Numerator / b.Denominator))
                  );
        
        set.Add(new Fraction(0, 1));
        for (var i = 1; i <= n; i++)
        {
            for (var j = i + 1; j <= n; j++)
            {
                set.Add(new Fraction(i, j));
            }
        }

        set.Add(new Fraction(1, 1));
        return set;
    }

    static IEnumerable<Fraction> FareyWeird(this int n)
    {
        return new List<Fraction>(); 
    }

    static void Main()
    {
        for (var i = 1; i < 10; i++)
        {
            Console.WriteLine("Farey {0}", i);
            Console.WriteLine(String.Join(", ", i.Farey()));
            Console.WriteLine(String.Join(", ", i.FareyWeird()));
        }
    }
}
