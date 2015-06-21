using System;
using System.Collections.Generic;
using System.Threading;

class ConcurrentQueue {
    private readonly Object locker = new Object();
    private readonly Queue<String> tasks = new Queue<String>();
    private readonly AutoResetEvent tasksExist = new AutoResetEvent(false);

    public void Add(String task) {
        lock(locker) {
            tasks.Enqueue(task);
        }

        tasksExist.Set();
    }

    public String Get() {
        tasksExist.WaitOne();
        lock(locker) {
             return tasks.Dequeue();
        }
    }
}

class Program {
    static void Main() {
        ConcurrentQueue queue = new ConcurrentQueue();
        for (int i = 0; i < 10; i++) {
            int j = i;
            new Thread(() => {
                                    String task = queue.Get();
                                    Console.WriteLine("Eating task {0}", task);
                                    Thread.Sleep(new Random().Next(500,1000));
                             }).Start();

            new Thread(() => {
                                    String task = String.Format("Task {0}", j);
                                    Console.WriteLine("Adding task {0}", task);
                                    queue.Add(task);
                                    Thread.Sleep(new Random().Next(1500,2500));
                             }).Start();
        } 
    }
}
