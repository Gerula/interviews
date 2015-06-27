using System;

class Queue {
    private uint data;
    private uint size;

    public bool IsEmpty() {
        return size == 0;
    }

    public uint Peek() {
        return data % 10;
    }

    public uint Dequeue() {
        uint result = uint.MaxValue;
        if (size > 0) {
            result = data % 10;
            data /= 10;
            size--;
        }

        return result;
    }

    public void Enqueue(uint value) {
        uint position = (uint) Math.Pow(10, size) * value;
        size++;
        data += position;
    }
}

class Program {
    static void Main() {
        Queue q = new Queue();
        q.Enqueue(0);
        q.Enqueue(0);
        q.Enqueue(1);
        q.Enqueue(0);
        q.Enqueue(2);
        q.Enqueue(0);
        q.Enqueue(0);
        q.Enqueue(0);
        q.Enqueue(0);
        while (!q.IsEmpty()) {
            Console.Write("{0} ", q.Dequeue());
        }
    }
}
