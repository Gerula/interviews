using System;
using System.IO;

interface IStack<T> {
    IStack<T> Push(T value);
    IStack<T> Pop();
    T Peek();
    bool IsEmpty();
}

class Stack<T>: IStack<T> {
    private class EmptyStack: IStack<T> {
        public IStack<T> Push(T value) {
            return new Stack<T>(value, this);
        }

        public IStack<T> Pop() {
            throw new NotImplementedException();
        }

        public T Peek() {
            throw new NotImplementedException();
        }

        public bool IsEmpty() {
            return true;
        }
    }

    private static readonly EmptyStack empty = new EmptyStack();
    public static IStack<T> Empty { get {return empty; } }
    private readonly T Head;
    private readonly IStack<T> Tail;

    private Stack(T head, IStack<T> tail)
    {
        Head = head;
        Tail = tail;
    }

    public IStack<T> Push(T value)
    {
        return new Stack<T>(value, this);
    }

    public IStack<T> Pop()
    {
        return Tail;
    }

    public T Peek()
    {
        return Head;
    }

    public bool IsEmpty()
    {
        return false;
    }
}

class Program {
    static bool IsPrime(int x, IStack<int> primes)
    {
        while (!primes.IsEmpty())
        {
            if (x % primes.Peek() == 0) {
                return false;
            }

            primes = primes.Pop();
        }

        return true;
    }

    static IStack<int> GetPrimes(int n) {
        IStack<int> primes = Stack<int>.Empty.Push(2);
        for (int i = 3; i < n; i++)
        {
            if (IsPrime(i, primes)) {
                primes = primes.Push(i);
            }
        } 

        return primes;
    }

    static void Main() {
        IStack<int> stack = GetPrimes(30);
        while (!stack.IsEmpty())
        {
            Console.WriteLine("{0} ", stack.Peek());
            stack = stack.Pop();
        }
        
        Console.WriteLine();
    }
}
