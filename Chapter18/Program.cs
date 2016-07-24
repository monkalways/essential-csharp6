using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter18
{
    class Program
    {
        public const int Repetitions = 1000;

        static void Main(string[] args)
        {
            ThreadStart threadStart = DoWork;
            Thread thread = new Thread(threadStart);
            //thread.Priority = ThreadPriority.Highest;
            thread.Start();
            for (int count = 0; count < Repetitions; count++)
            {
                Console.Write("-");
            }
            thread.Join();
        }

        public static void DoWork()
        {
            for (int count = 0; count < Repetitions; count++)
            {
                Console.Write("+");
            }
        }
    }
}
