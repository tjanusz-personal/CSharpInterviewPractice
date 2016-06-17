using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewPractice
{
    [Synchronization]
    public class LockExample
    {
        public object tLock = new object();

        public void Calculate()
        {
            lock (tLock)
            {
                Console.Write(" {0} is Executing", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.Write(" {0},", i);
                }
                Console.WriteLine();
            }
        }
        
        public void CalculateWithSync()
        {
            Console.Write(" {0} is Executing WithSync", Thread.CurrentThread.Name);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(new Random().Next(5));
                Console.Write(" {0},", i);
            }
            Console.WriteLine();
        }

    }
}
