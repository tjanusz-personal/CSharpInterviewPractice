using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPracticeTest
{
    [TestClass]
    public class NumberPrinterTest
    {
        private NumberPrinter printer;

        [TestInitialize]
        public void setup()
        {
            printer = new NumberPrinter();
        }

        [TestMethod]
        public void GetNumbersUsingWhereReturnsOnlyNumbersFromString()
        {
            Assert.AreEqual("123", printer.GetNumbersUsingWhere("Hello12This3"));
        }

        [TestMethod]
        public void GetNumbersUsingWhereReturnsEmptyStringWithNullString()
        {
            Assert.AreEqual("", printer.GetNumbersUsingWhere(null));
        }

        [TestMethod]
        public void GetNumbersUsingForEachLoopReturnsOnlyNumbersFromString()
        {
            Assert.AreEqual("123", printer.GetNumbersUsingForEachLoop("Hello12This3"));
        }

        [TestMethod]
        public void GetNumbersUsingForEachLoopReturnsEmptyStringWithNullString()
        {
            Assert.AreEqual("", printer.GetNumbersUsingForEachLoop(null));
        }

        [TestMethod]
        public void GetNumbersUsingForLoopReturnsOnlyNumbersFromString()
        {
            Assert.AreEqual("123", printer.GetNumbersUsingForLoop("Hello12This3"));
        }

        [TestMethod]
        public void GetNumbersUsingForLoopReturnsEmptyStringWithNullString()
        {
            Assert.AreEqual("", printer.GetNumbersUsingForLoop(null));
        }

        [TestMethod]
        public void GetNumbersUsingLinqReturnsOnlyNumbersFromString()
        {
            Assert.AreEqual("123", printer.GetNumbersUsingLinq("Hello12This3"));
        }

        [TestMethod]
        public void GetNumbersUsingLinqReturnsEmptyStringWithEmptyString()
        {
            Assert.AreEqual("", printer.GetNumbersUsingLinq(""));
        }

        [TestMethod]
        public void GetNumbersUsingLinqReturnsEmptyStringWithNull()
        {
            Assert.AreEqual("", printer.GetNumbersUsingLinq(null));
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithMatchingWordsRegardlessOfCase()
        {
            Assert.AreEqual(3, printer.CountWordsInString("Hello", "Hello Hello Helll HELLO To You"));
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithNoMatchingWords()
        {
            Assert.AreEqual(0, printer.CountWordsInString("HelloX", "Hello Hello Helll To You"));
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithSingleString()
        {
            Assert.AreEqual(0, printer.CountWordsInString("Hello", "HelloHelloHelllToYou"));
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithNullString()
        {
            Assert.AreEqual(0, printer.CountWordsInString("Hello", null));
        }

        [TestMethod]
        public void SortWordsAlphabeticallySortsWordsInAlphabeticalOrder()
        {
            String sortedResult = printer.SortWordsAlphabetically("AAA DDD CCC BBB");
            Assert.AreEqual("AAA BBB CCC DDD", sortedResult);
        }

        [TestMethod]
        public void SortWordsAlphabeticallyReturnsEmptyStringWithNullArgument()
        {
            Assert.AreEqual("", printer.SortWordsAlphabetically(null));
        }

        [TestMethod]
        public void SentanceContainsWordsReturnsTrueWhenSentanceContainsWords()
        {
            string[] wordsToFind = { "AAA", "CCC" };
            Assert.IsTrue(printer.SentanceContainsWords("AAA BBB CCC. AAA BBB DDD.", wordsToFind));
        }

        [TestMethod]
        public void SentanceContainsWordsReturnsFalseWhenSentanceHasNoWords()
        {
            string[] wordsToFind = { "AAA", "CCC" };
            Assert.IsFalse(printer.SentanceContainsWords("BBB. AAA DDD.", wordsToFind));
        }

        [TestMethod]
        public void SentanceContainsWordsReturnsFalseWhenSentanceIsNull()
        {
            string[] wordsToFind = { "AAA", "CCC" };
            Assert.IsFalse(printer.SentanceContainsWords(null, wordsToFind));
        }

    }
}
