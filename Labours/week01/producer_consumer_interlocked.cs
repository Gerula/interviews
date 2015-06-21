using System;
using System.Threading;

class Program {
    static void Main() {
        int size = 10;
        int[] buff = new int[size];
        int produceCount = 0;
        int consumeCount = 0;
        new Thread(() => {
                            while(true) {
                                while (produceCount - consumeCount == size) {
                                    Thread.Yield();
                                }
                                buff[produceCount % size] = new Random().Next(1, 10);
                                Console.WriteLine("Producing {0}", buff[produceCount % size]);
                                Interlocked.Increment(ref produceCount);
                            }
                         }).Start();

        new Thread(() => {
                            while (true) {
                                while (produceCount - consumeCount == 0) {
                                }

                                Console.WriteLine("Consuming {0}", buff[consumeCount % size]);
                                Interlocked.Increment(ref consumeCount);
                            }
                         }).Start();
    }
}
