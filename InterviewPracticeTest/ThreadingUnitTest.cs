using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace InterviewPracticeTest
{
    [TestClass]
    public class ThreadingUnitTest
    {
        private StreamWriter standardOut;
        private StringWriter stubbedConsoleOutput;

        [TestInitialize]
        public void SetupConsole()
        {
            // Capture current standard out
            standardOut = new StreamWriter(Console.OpenStandardOutput());
            // Create and set stub for Console output
            stubbedConsoleOutput = new StringWriter();
            Console.SetOut(stubbedConsoleOutput);
        }

        [TestCleanup]
        public void Teardown()
        {
            // reset current standard output
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [TestMethod]
        public void LockExampleWorks()
        {
            LockExample lockExample = new LockExample();
            Thread[] tr = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(lockExample.Calculate));
                tr[i].Name = String.Format("Working Thread: {0}", i);
            }
            Array.ForEach(tr, x => x.Start());
            Array.ForEach(tr, x => x.Join());
            var consoleOutput = stubbedConsoleOutput.ToString();
            StringAssert.Contains(consoleOutput, "Working Thread: 0 is Executing 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,");
            StringAssert.Contains(consoleOutput, "Working Thread: 1 is Executing 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,");
            StringAssert.Contains(consoleOutput, "Working Thread: 2 is Executing 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,");
            StringAssert.Contains(consoleOutput, "Working Thread: 3 is Executing 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,");
        }

        [TestMethod]
        public void LockExampleWorksForClass()
        {
            LockExample lockExample = new LockExample();
            Thread[] tr = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(lockExample.CalculateWithSync));
                tr[i].Name = String.Format("Working Thread: {0}", i);
            }
            Array.ForEach(tr, x => x.Start());
        }

        [TestMethod]
        public void RedirectConsole()
        {
            Console.Write("200");
            var result = stubbedConsoleOutput.ToString();
            Assert.IsFalse(result.Contains("7"));
        }

        [TestMethod]
        public void ThreadWaitsOnSemExampleShowsThreadsWaitingBeforeFinishing()
        {
            List<Thread> theThreads = SemaphoreExample.ThreadWaitsOnSemExample();
            var consoleOutput = stubbedConsoleOutput.ToString();
            int startPos = consoleOutput.IndexOf("Done starting all threads! Now waiting for them to finish");
            int endPos = consoleOutput.IndexOf("Success: 4 is in!");
            Assert.IsTrue(startPos < endPos);
            StringAssert.Contains(consoleOutput, "Done waiting on all threads");
        }

    }
}
