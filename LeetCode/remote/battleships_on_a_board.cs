//  https://leetcode.com/problems/battleships-in-a-board/
//
//  https://leetcode.com/submissions/detail/84300931/
//  Submission Details
//  28 / 28 test cases passed.
//      Status: Accepted
//      Runtime: 129 ms
//
//          Submitted: 0 minutes ago
//
public class Solution {
    public int CountBattleships(char[,] board) {
        var count = 0;
        for (var i = 0; i < board.GetLength(0); i++) {
            for (var j = 0; j < board.GetLength(1); j++) {
                if (board[i, j] == 'X' && 
                    (i == 0 || board[i - 1, j] != 'X') &&
                    (j == 0 || board[i, j - 1] != 'X')) {
                        count++;
                    }
            }
        }

        return count;
    }
}
