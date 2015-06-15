using System;
using System.IO;

class Program {

    class Singleton {
        public string Message {get; private set;}
        private static Singleton instance = new Singleton();

        private Singleton() {
            Message = "Hello right back.";
        }

        public static Singleton Instance {
            get {
                return instance;
            }
        }
    }

    public static void Main(string[] args) {
        Console.WriteLine("Hello Singleton {0}", Singleton.Instance.Message);
    }
}
