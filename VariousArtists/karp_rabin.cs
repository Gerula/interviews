using System;

class RollingHash {
    public long Data { get; private set; }
    public long Size { get; private set; }
    private const long alphabetSize = 255; 
    private const long mod = 997;

    public void Append(char c) {
        Data = Data * alphabetSize + c;
        Size++;
    }

    public void Skip() {
        Data = Data % (long) Math.Pow(alphabetSize, Size - 1);
        Size--;
    }

    public bool Equals(RollingHash other) {
        return Data == other.Data;
    }
}

class Program {
    static int Search(String s, String t) {
        RollingHash sh = new RollingHash();
        foreach (char c in s) {
            sh.Append(c);
        }
        
        RollingHash th = new RollingHash();
        for (int i = 0; i < t.Length; i++) {
            if (th.Size == s.Length) { 
                th.Skip();
            }

            th.Append(t[i]);
            if (sh.Equals(th)){
                if (Match(s, t, i - s.Length + 1)) {
                    return i;
                }
            }
        }

        return -1;
    }

    static bool Match(String s, String t, int start) {
        int sidx = 0;
        while (sidx < s.Length && s[sidx] == t[start]) {
            sidx++; start++;
        }

        return sidx == s.Length;
    }

    static void Main() {
        Console.WriteLine(Search("abcdefg","aaaaaabcdefgaaa"));
        Console.WriteLine(Search("abcdefgh","aaaaaabcdefgaaa"));
    }
}
