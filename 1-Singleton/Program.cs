using System;

namespace _1_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Singleton
    {
        private static Singleton _instance;

        //can't be init with construction
        private Singleton(){}

        public static Singleton Instance
        {
            get
            {
                if(_instance ==null)
                    _instance = new Singleton();
                return _instance; // always return the same instance
            }
        }
    }
}
