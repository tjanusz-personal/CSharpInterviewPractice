using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class SemaphoreExample
    {
        public static void SempStart(object id)
        {
            Console.WriteLine(id + "-->> Trying to get SEM");
            try
            {
                InterviewPractice.Program.OBJ_SEM.WaitOne();
                Console.WriteLine(" Success: " + id + " is in!");
                Thread.Sleep(1000);
                Console.WriteLine(id + "<<-- is Releasing SEM");
            }
            finally
            {
                InterviewPractice.Program.OBJ_SEM.Release();
            }
        }

        public static List<Thread> ThreadWaitsOnSemExample()
        {
            List<Thread> theThreads = new List<Thread>();
            for (int i = 1; i <= 5; i++)
            {
                Thread T1 = new Thread(SemaphoreExample.SempStart);
                theThreads.Add(T1);
                T1.Start(i);
            }
            Console.WriteLine("Done starting all threads! Now waiting for them to finish");
            theThreads.ForEach(x => x.Join());
            Console.WriteLine("Done waiting on all threads!");
            return theThreads;
        }
    }
}
