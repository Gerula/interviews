using System;

class Program {
    class Node {
        public int Data { get; set; }
        public Node Next { get; set; }
    
        public override String ToString() {
            return String.Format("{0} {1}", Data, Next == null ? String.Empty : Next.ToString());
        }

        public Node Rotate(int k) {
            Node last = this;
            Node kLast = this;
            for (int i = 0; i < k; i++) {
                kLast = kLast.Next;
            }

            while (kLast.Next != null) {
               kLast = kLast.Next;
               last = last.Next; 
            }

            Node result = last.Next;
            last.Next = null;
            kLast.Next = this;
            return result;
        }
    }

    static void Main() {
        Node head = null;
        head = new Node { Data = 5, Next = head };
        head = new Node { Data = 4, Next = head };
        head = new Node { Data = 3, Next = head };
        head = new Node { Data = 2, Next = head };
        head = new Node { Data = 1, Next = head };
        Console.WriteLine(head);
        Console.WriteLine(head.Rotate(2));
    }
}


