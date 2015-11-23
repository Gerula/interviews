// Find the longest common subseq of a bunch of strings

using System;
using System.Linq;
using System.Text;

class Program
{
    static String Lcs(String a, String b)
    {
        var dp = new int[a.Length + 1, b.Length + 1];
        for (var i = 0; i <= a.Length; i++)
        {
            for (var j = 0; j <= b.Length; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 0;
                    continue;
                }

                dp[i, j] = a[i - 1] == b[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        var result = new StringBuilder();
        var line = a.Length;
        var col = b.Length;
        while (line > 0 && col > 0)
        {
            if (a[line - 1] == b[col - 1])
            {
                result.Insert(0, a[line - 1]);
            }

            if (dp[line - 1, col] > dp[line, col - 1])
            {
                line--;
            }
            else
            {
                col--;
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine(new [] { 
                                "ABCDHIG",
                                "AEDFHRI",
                                "ACDHJ"
                            }
                            .Aggregate(
                                    String.Empty,
                                    (acc, x) => {
                                        if (String.IsNullOrWhiteSpace(acc))
                                        {
                                            return x;
                                        }

                                        return Lcs(acc, x);
                                    }));
    }
}
