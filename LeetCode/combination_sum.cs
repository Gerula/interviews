using System;

class Program {

    static void CombinationSum(int[] input, int step, int currentSum, int sum, int[] output)
    {
        if (currentSum == sum) {
            for (int i = 0; i < step; i++) {
                Console.Write("{0} ", output[i]);
            }

            Console.WriteLine();
        }

        for (int i = 0; i < input.Length; i++) {
            int newSum = currentSum + input[i];
            if ((newSum <= sum) && (step == 0 || output[step] <= input[i])) {
                output[step] = input[i];
                CombinationSum(input, step + 1, newSum, sum, output);
            }
        }
    }

    static void Main() {
        int[] input = new int[] {2, 3, 6, 7};
        CombinationSum(input, 0, 0, 7, new int[input.Length]);
    }
}
