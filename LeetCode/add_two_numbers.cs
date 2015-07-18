using System;

class Program {
    class Node {
        public int Value { get; set; }
        public Node Next { get; set; }
    
        public Node Add(Node second) {
            Node prev = null;
            Node result = null;
            Node first = this;
            int carry = 0;
            while (first != null || second != null) {
                int sum = (first == null? 0 : first.Value) + 
                          (second == null? 0 : second.Value);

                Node current = new Node {Value = sum % 10 + carry };
                carry = sum / 10;
                if (prev == null) {
                    result = current;
                    prev = current;
                } else {
                    prev.Next = current;
                    prev = current;
                }
                
                first = first == null ? null : first.Next;
                second = second == null ? null : second.Next;
            }

            return result;
        }

        public override String ToString() {
            return String.Format("{0} {1}", Value, Next != null ? Next.ToString() : String.Empty);
        }
    }

    static void Main() {
        Node a = null;
        a = new Node { Value = 3, Next = a };
        a = new Node { Value = 4, Next = a };
        a = new Node { Value = 2, Next = a };

        Node b = null;
        b = new Node { Value = 4, Next = b };
        b = new Node { Value = 6, Next = b };
        b = new Node { Value = 5, Next = b };

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(a.Add(b));
    }
}
