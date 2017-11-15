using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{

    /// <summary>
    /// Write two basic extention methods: SayHello and SayGoodbye. Examples: string name = "Kathy" 
    /// name.SayHello() --> "Hello, Kathy!"
    /// name.SayGoodbye() --> "Goodbye, Kathy. See you again soon!"
    /// </summary>
    class Task3
    {
        static void Main(string[] args)
        {
            string name = "Kathy";
            Console.WriteLine(name.SayHello());
            Console.WriteLine(name.SayGoodbye());
            Console.ReadLine();
        }
    }

    static class MySecondExtention
    {
        public static string SayHello(this String username)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Hello, {0}!", username);
            return sb.ToString();
        }

        public static string SayGoodbye(this String username)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Goodbye, {0}. See you again soon!", username);
            return sb.ToString();
        }
    }
}
