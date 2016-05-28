//  https://leetcode.com/problems/decode-ways/
//  TLE
public class Solution {
    public int NumDecodings(string s) {
        if (s.Length < 2) {
            return s.Length;
        }
        
        if (s[0] == '0')
        {
            return 1 + NumDecodings(s.Substring(1));
        }
        
        return 1 + 
               (s.Length >= 2 && int.Parse(s.Substring(0, 2)) > 26 ? 0 : NumDecodings(s.Substring(2))) + 
               NumDecodings(s.Substring(1));
    }
}
