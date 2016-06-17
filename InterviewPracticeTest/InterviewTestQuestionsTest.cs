using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Threading.Tasks;

namespace InterviewPracticeTest
{
    [TestClass]
    public class InterviewTestQuestionsTest
    {
        private InterviewTestQuestions tester;
        [TestInitialize]
        public void Setup()
        {
            tester = new InterviewTestQuestions();
        }

        [TestMethod]
        public void SumOfEvenArrayReturnsTotal()
        {
            int[] intArray = new int[3] { 1, 2, 4};
            Assert.AreEqual(6, tester.SumOfEvenArray(intArray));
        }

        [TestMethod]
        public void SumOfEvenArrayReturnsZeroOnEmptyArray()
        {
            int[] intArray = new int[] { };
            Assert.AreEqual(0, tester.SumOfEvenArray(intArray));
        }

        [TestMethod]
        public void SumOfEvenArrayReturnsZeroOnNull()
        {
            Assert.AreEqual(0, tester.SumOfEvenArray(null));
        }

        [TestMethod]
        public void StaticDefaultOfStringInitializesNull()
        {
            Assert.IsNull(InterviewTestQuestions.location);
        }

        [TestMethod]
        public void StaticDefaultOfDateTimeInitializesNull()
        {
            Assert.IsNotNull(InterviewTestQuestions.time);
        }

        [TestMethod]
        public void SaySomethingImmediatelyReturnsBeforeInitializingStaticValue()
        {
            Task<String> resultTask = InterviewTestQuestions.SaySomething();
            Assert.AreEqual(TaskStatus.WaitingForActivation, resultTask.Status);
            Assert.IsNull(InterviewTestQuestions.result);
        }

    }
}
