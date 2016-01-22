//  https://en.wikipedia.org/wiki/Farey_sequence
//
//  This sequence twiddles my diddle.

using System;
using System.Collections.Generic;
using System.Linq;

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

    static SortedSet<Fraction> AbracadabraSet()
    {
        return new SortedSet<Fraction>(
                    Comparer<Fraction>.Create((a, b) => 
                        ((double) a.Numerator / a.Denominator)
                        .CompareTo((double) b.Numerator / b.Denominator))
                  );
    }

    static IEnumerable<Fraction> Farey(this int n)
    {
        var set = AbracadabraSet();
        
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
        var result = AbracadabraSet();
        if (n == 1)
        {
            result.Add(new Fraction(0, 1));
            result.Add(new Fraction(1, 1));
            return result;
        }
        
        foreach (var x in (n - 1).FareyWeird())
        {
            result.Add(x);
        }

        foreach (var x in Enumerable
                          .Range(1, n)
                          .Where(x => x.Coprime(n)))
        {
            result.Add(new Fraction(x, n));
        }

        return result;
    }

    static bool Coprime(this int a, int b)
    {
        while (a != b)
        {
            if (a > b)
            {
                a -= b;
            }
            else
            {
                b -= a;
            }
        }

        return a == 1;
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
