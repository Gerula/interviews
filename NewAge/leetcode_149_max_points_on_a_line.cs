//  https://leetcode.com/problems/max-points-on-a-line/
//  https://leetcode.com/submissions/detail/87813052/

/**
 * Definition for a point.
 * public class Point {
 *     public int x;
 *     public int y;
 *     public Point() { x = 0; y = 0; }
 *     public Point(int a, int b) { x = a; y = b; }
 * }
 */
public class Solution {
    public int MaxPoints(Point[] points) {
        if (!points.Any()) {
            return 0;
        }

        var maxPoints = 1;
        for (var i = 0; i < points.Length - 1; i++) {
            var slopeCount = new Dictionary<double, int>();
            var duplicates = 0;
            var localMaxPoints = 1;
            for (var j = i + 1; j < points.Length; j++) {
                if (points[i].x == points[j].x &&
                    points[i].y == points[j].y) {
                    duplicates++;
                    continue;
                }

                var run = points[j].x - points[i].x;
                var rise = points[j].y - points[i].y;
                var slope = run == 0 ? Double.MaxValue : rise / (double) run;
                if (!slopeCount.ContainsKey(slope)) {
                    slopeCount[slope] = 1;
                }

                slopeCount[slope]++;
                localMaxPoints = Math.Max(localMaxPoints, slopeCount[slope]);
            }

            maxPoints = Math.Max(maxPoints, localMaxPoints + duplicates);
        }

        return maxPoints;
    }
}
