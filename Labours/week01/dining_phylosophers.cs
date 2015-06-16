using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Phylosopher {
    private readonly Mutex _leftFork;
    private readonly Mutex _rightFork;
    private readonly Semaphore _waiter;
    private readonly int _id;
    private readonly Random _rand = new Random();

    public Phylosopher(int id, Mutex left, Mutex right, Semaphore waiter) {
        _id = id; _leftFork = left; _rightFork = right; _waiter = waiter;
    }

    private void Think() {
        Console.WriteLine("{0} - thinking", _id);
        Thread.Sleep(_rand.Next(1, 3) * 1000);
    }

    private void Eat() {
        _waiter.WaitOne();
        _leftFork.WaitOne();
        _rightFork.WaitOne();
        Console.WriteLine("{0} - eating", _id);
        Thread.Sleep(_rand.Next(1, 3) * 1000);
        _rightFork.ReleaseMutex();
        _leftFork.ReleaseMutex();
        _waiter.Release(); 
    }

    public void Live() {
        new Thread(() => {
            while(true) {
                Think();
                Eat();
            }
        }).Start();
    }
}

class Program {
    public static void Main(string[] args) {
        Semaphore waiter = new Semaphore(0, 2);
        Mutex[] forks = Enumerable.Range(0, 5).Select(x => new Mutex()).ToArray();
        List<Phylosopher> typos = Enumerable.Range(0, 5).Select(x => new Phylosopher(x, forks[x], forks[(x + 1) % 5], waiter)).ToList();
        typos.ForEach(x => x.Live());
        Console.ReadLine();
        waiter.Release(2);
    }
}
