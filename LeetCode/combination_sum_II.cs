using System;

class Program {
    static void Combinations(int[] numbers, int[] result, int target, int nums, int step, int partial) {
        if (partial == target) {
            for (int i = 0; i < step; i++) {
                Console.Write("{0} ", result[i]);
            }

            Console.WriteLine();
        }
        
        for (int i = nums; i < numbers.Length; i++) {
            if (partial + numbers[i] <= target && (step == 0 || result[step - 1] <= numbers[i])) {
                result[step] = numbers[i];
                Combinations(numbers, result, target, nums, step + 1, partial + numbers[i]);
            }
        }
    }

    static void Main() {
        int[] numbers = new int[] {2, 6, 3, 7};
        int sum = 7;
        Combinations(numbers, new int[numbers.Length], sum, 0, 0, 0);
    }
}
