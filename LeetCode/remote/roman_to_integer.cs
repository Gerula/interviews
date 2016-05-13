//  https://leetcode.com/problems/roman-to-integer/
//  https://leetcode.com/submissions/detail/61390098/
public class Solution {
    public int RomanToInt(string s) {
        if (String.IsNullOrWhiteSpace(s))
        {
            return 0;
        }
        
        var pattern = s.Substring(0, Math.Min(2, s.Length));
        switch (pattern)
        {
            case "IV" : return 4    + RomanToInt(s.Substring(pattern.Length));
            case "IX" : return 9    + RomanToInt(s.Substring(pattern.Length));
            case "XL" : return 40   + RomanToInt(s.Substring(pattern.Length));
            case "XC" : return 90   + RomanToInt(s.Substring(pattern.Length));
            case "CD" : return 400  + RomanToInt(s.Substring(pattern.Length));
            case "CM" : return 900  + RomanToInt(s.Substring(pattern.Length));
        }
        
        pattern = s.Substring(0, 1);
        switch (pattern)
        {
            case "I" : return 1     + RomanToInt(s.Substring(pattern.Length));
            case "V" : return 5     + RomanToInt(s.Substring(pattern.Length));
            case "X" : return 10    + RomanToInt(s.Substring(pattern.Length));
            case "L" : return 50    + RomanToInt(s.Substring(pattern.Length));
            case "C" : return 100   + RomanToInt(s.Substring(pattern.Length));
            case "D" : return 500   + RomanToInt(s.Substring(pattern.Length));
            case "M" : return 1000  + RomanToInt(s.Substring(pattern.Length));
        }
        
        return 0;
    }
}
