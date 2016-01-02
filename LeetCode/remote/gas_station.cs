//  https://leetcode.com/problems/gas-station/
//
//   There are N gas stations along a circular route, where the amount of gas at station i is gas[i].
//
//   You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1).
//   You begin the journey with an empty tank at one of the gas stations.
//
//   Return the starting gas station's index if you can travel around the circuit once, otherwise return -1.

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  16 / 16 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49525049/
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var minIndex = 0;
        var minGas = 0;
        var currentGas = 0;
        for (var i = 1; i < gas.Length; i++)
        {
            currentGas += gas[i - 1] - cost[i - 1];
            if (currentGas < minGas)
            {
                minIndex = i;
                minGas = currentGas;
            }
        }

        currentGas += gas[gas.Length - 1] - cost[gas.Length - 1];

        return currentGas < 0 ? -1 : minIndex;
    }

    static void Main()
    {
        var r = new Random();
        var times = r.Next(2, 10);
        for (var i = 0; i < times; i++)
        {
            var count = r.Next(5, 10);
            var gas = Enumerable.Range(1, count).Select(x => r.Next(1, 10)).ToArray();
            var cost = Enumerable.Range(1, count).Select(x => r.Next(1, 10)).ToArray();

            Console.WriteLine(
                    "Cost: {0} \nGas: {1} \nResult: {2}",
                    String.Join(", ", cost),
                    String.Join(", ", gas),
                    new Solution().CanCompleteCircuit(gas, cost));
        }
    }
}
