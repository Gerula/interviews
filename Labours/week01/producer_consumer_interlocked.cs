using System;
using System.Threading;

class Program {
    static void Main() {
        int size = 10;
        int[] buff = new int[size];
        int totalCount = 0;
        new Thread(() => {
                            while(true) {
                                while (totalCount == size) {
                                    Thread.Yield();
                                }

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
