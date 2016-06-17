using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewPractice
{
    class Program
    {
        public static Semaphore OBJ_SEM = new Semaphore(2, 4);

        static void Main(string[] args)
        {
            RunSemaphoreExample();
        }

        static void RunFizzBuzz()
        {
            FizBuzz fizBuzz = new FizBuzz();
            fizBuzz.printFizzBuzz();
        }

        static void RunSemaphoreExample()
        {
            SemaphoreExample.ThreadWaitsOnSemExample();
        }
    }
}
