using System;

class RandomGenerator {
    private long _previous;
    private const long _limit = 100000000;
    private const long _multiplier = 124354321;

    public static RandomGenerator GetInstance(long seed) {
        return new RandomGenerator(seed);
    }

    private RandomGenerator(long seed) {
        _previous = seed;
    }

    public long Next(long range) {
        _previous = (_previous * _multiplier + 1) % _limit;
        return _previous % range; 
    }
}

class Program {
    static void Main() {
        RandomGenerator random = RandomGenerator.GetInstance(DateTime.Now.Ticks); 
        for (int i = 0; i < 10; i++) {
            Console.WriteLine("Random: {0}", random.Next(100));
        }
    }
}
