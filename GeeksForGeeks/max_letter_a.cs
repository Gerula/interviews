//  http://www.geeksforgeeks.org/how-to-print-maximum-number-of-a-using-given-four-keys/
//
//  This is a famous interview question asked in Google, Paytm and many other company interviews.
//
//  Below is the problem statement.
//
//  Imagine you have a special keyboard with the following keys: 
//  Key 1:  Prints 'A' on screen
//  Key 2: (Ctrl-A): Select screen
//  Key 3: (Ctrl-C): Copy selection to buffer
//  Key 4: (Ctrl-V): Print buffer on screen appending it
//                   after what has already been printed. 
//
//  If you can only press the keyboard for N times (with the above four
//  keys), write a program to produce maximum numbers of A's. That is to
//  say, the input parameter is N (No. of keys that you can press), the 
//  output is M (No. of As that you can produce).

using System;

static class Program
{
    static int Max(this int n)
    {
        if (n <= 6)
        {
            return n;
        }

        var max = int.MinValue;
        for (var i = n - 3; i >= 1; i--)
        {
            max = Math.Max(max, (n - i - 1) * i.Max());
        }

        return max;
    }

    static int Max2(this int n)
    {
        var dp = new int[n];
        if (n < 7)
        {
            return n;
        }

        for (var i = 1; i < 7; i++)
        {
            dp[i - 1] = i;
        }

        for (var i = 7; i <= n; i++)
        {
            dp[i - 1] = int.MinValue;
            for (var b = i - 3; b >= 1; b--)
            {
                dp[i - 1] = Math.Max(dp[i - 1], (i - b - 1) * dp[b - 1]);
            }
        }

        return dp[n - 1];
    }

    static void Main()
    {
        foreach (var x in new [] { 3, 7, 11 })
        {
            Console.WriteLine("{0} = {1} {2}", x, x.Max(), x.Max2());
        }
    }
}
