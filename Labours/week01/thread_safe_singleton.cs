using System;
using System.IO;

class Program {

    class Singleton {
        public string Message {get; private set;}
        private static Lazy<Singleton> Lazy = new Lazy<Singleton>(() => new Singleton());

        private Singleton() {
            Message = "Hello right back.";
        }

        public static Singleton Instance {
            get {
                return Lazy.Value;
            }
        }
    }

    public static void Main(string[] args) {
        Console.WriteLine("Hello Singleton {0}", Singleton.Instance.Message);
    }
}
