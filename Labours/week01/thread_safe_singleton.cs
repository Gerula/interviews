using System;
using System.IO;

class Program {

    class Singleton {
        public string Message {get; private set;}
        private static Object padLock = new Object();
        private static Singleton instance = null;

        private Singleton() {
            Message = "Hello right back.";
        }

        public static Singleton Instance {
            get {
                if (instance == null) {
                    lock (padLock) {
                        if (instance == null) {
                            instance = new Singleton();
                            return instance;
                        }
                    }
                }

                return instance;
            }
        }
    }

    public static void Main(string[] args) {
        Console.WriteLine("Hello Singleton {0}", Singleton.Instance.Message);
    }
}
