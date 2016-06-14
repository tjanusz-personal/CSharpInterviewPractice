using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InterviewPracticeTest
{
    [TestClass]
    public class PowerOfTwoTest
    {
        private PowerOfTwo powerOfTwo;

        [TestInitialize]
        public void setUp() 
        {
            powerOfTwo = new PowerOfTwo();
        }

        [TestMethod]
        public void IsPowerOfTwoUsingDecimalReturnsTrueForBasicValues()
        {
            List<ulong> validValues = new List<ulong>() { 2, 4, 8 };
            validValues.ForEach(x =>
            {
                Assert.IsTrue(powerOfTwo.IsPowerOfTwoUsingDecimal(x));
            });
        }

        [TestMethod]
        public void IsPowerOfTwoUsingDecimalReturnsFalseForNonBasicValues()
        {
            List<ulong> validValues = new List<ulong>() {1, 3, 5, 6, 7, 9, 10, 11 };
            validValues.ForEach(x =>
            {
                Assert.IsFalse(powerOfTwo.IsPowerOfTwoUsingDecimal(x));
            });
        }

        [TestMethod]
        public void IsPowerOfTwoUsingDecimalReturnsFalseForZeroValue()
        {
            Assert.IsFalse(powerOfTwo.IsPowerOfTwoUsingDecimal(0));
        }

        [TestMethod]
        public void IsPowerOfTwoUsingDecimalReturnsTrueForAllFactorOfTwoValuesFittingInsideULongType()
        {
            List<ulong> validValues = GenerateListOf2PowersForUlong();
            validValues.ForEach(x =>
            {
                Assert.IsTrue(powerOfTwo.IsPowerOfTwoUsingDecimal(x));
            });
        }

        [TestMethod]
        public void IsPowerOfTwoUsingDecimalReturnsFalseForLargeULongNumber()
        {
            Assert.IsFalse(powerOfTwo.IsPowerOfTwoUsingDecimal(PowerOfTwo.LARGEST_ULONG_POWER + 1));
        }

        [TestMethod]
        public void IsPowerOfTwoUsingDecimalReturnsTrueForLargestULongPower()
        {
            Assert.IsTrue(powerOfTwo.IsPowerOfTwoUsingDecimal(PowerOfTwo.LARGEST_ULONG_POWER));
        }

        private List<ulong> GenerateListOf2PowersForUlong()
        {
            List<ulong> validValues = new List<ulong>();
            // ULONG size is: 18,446,744,073,709,551,615, largest power of two that fits is 63..
            // TODO: can do this using Enumerable somehow?
            for (int i = 1; i < 64; i++)
            {
                validValues.Add(Convert.ToUInt64(Math.Pow(2, i)));
            }
            return validValues;
        }

        [TestMethod]
        public void IsPowerOfTwoUsingBinaryReturnsTrueForAllFactorOfTwoValuesFittingInsideULongType()
        {
            List<ulong> validValues = GenerateListOf2PowersForUlong();
            validValues.ForEach(x =>
            {
                Assert.IsTrue(powerOfTwo.IsPowerOfTwoUsingBinary(x));
            });
        }

        [TestMethod]
        public void IsPowerOfTwoUsingBinaryReturnsFalseForLargeULongNumber()
        {
            Assert.IsFalse(powerOfTwo.IsPowerOfTwoUsingBinary(PowerOfTwo.LARGEST_ULONG_POWER + 1));
        }

        [TestMethod]
        public void IsPowerOfTwoUsingBinaryReturnsTrueForLargestULongPower()
        {
            Assert.IsTrue(powerOfTwo.IsPowerOfTwoUsingBinary(PowerOfTwo.LARGEST_ULONG_POWER));
        }


    }
}
