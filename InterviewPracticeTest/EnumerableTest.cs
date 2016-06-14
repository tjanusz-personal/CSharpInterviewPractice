using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace InterviewPracticeTest
{
    [TestClass]
    public class EnumerableTest
    {

        [TestInitialize]
        public void setup()
        {
        }

        [TestMethod]
        public void IntersectOnTwoEnumerablesReturnsIntersectionWithOneMatchingItem()
        {
            string[] someWords = { "AAA", "CCC" };
            string[] moreWords = { "AAA", "DDD" };
            IEnumerable<string> stringsInCommon = someWords.Intersect(moreWords);
            Assert.AreEqual(1, stringsInCommon.Count());
            Assert.IsTrue(stringsInCommon.Any());
            Assert.AreEqual("AAA", stringsInCommon.First());
            string[] expectedArray = { "AAA" };
            CollectionAssert.AreEqual( expectedArray, stringsInCommon.ToArray());
        }

        [TestMethod]
        public void IntersectOnTwoEnumerablesReturnsIntersectionWithTwoMatchingItems()
        {
            string[] moreWords = { "AAA", "DDD" };
            string[] someWords = { "AAA", "CCC", "DDD", "AAA" };
            IEnumerable<string> stringsInCommon = someWords.Intersect(moreWords);
            Assert.AreEqual(2, stringsInCommon.Count());
            CollectionAssert.AreEqual(moreWords, stringsInCommon.ToArray());
        }

        [TestMethod]
        public void ExceptOnTwoEnumerablesReturnsNonMatchingItems()
        {
            string[] someWords = { "AAA", "CCC", "DDD", "EEE" };
            string[] moreWords = { "AAA", "DDD" };
            IEnumerable<string> stringsNotInCommon = someWords.Except(moreWords);
            string[] nonMatchingItems = { "CCC", "EEE" };
            CollectionAssert.AreEqual(nonMatchingItems, stringsNotInCommon.ToArray());
        }

        private IEnumerable<String> getStringList()
        {
            List<String> stringList = new List<String>() { "AAA", "BBBB", "CCCC" };
            return stringList.AsEnumerable();
        }

        [TestMethod]
        public void AnyReturnsTrueForFoundItem()
        {
            Assert.IsTrue(getStringList().Any());
            Assert.IsTrue(getStringList().Any(s => s.Length == 3));
            Assert.IsTrue(getStringList().Any(s => s.Equals("AAA")));
        }

        [TestMethod]
        public void AverageReturnsAverageStringLengths()
        {
            double average = getStringList().Average(s => s.Length);
            Assert.AreEqual(3.67, average, .01);
        }

        [TestMethod]
        public void CountReturnsTotalCountOfStrings()
        {
            Assert.AreEqual(3, getStringList().Count());
        }

        [TestMethod]
        public void CountReturnsTotalCountOfStringsWithLength4()
        {
            Assert.AreEqual(2, getStringList().Count(s => s.Length == 4));
        }

        [TestMethod]
        public void DistinctReturnsUniqueSet()
        {
            List<String> stringList = new List<String>() { "AAA", "BBBB", "BBBB" };
            string[] distinctItems = { "AAA", "BBBB" };
            CollectionAssert.AreEqual(distinctItems, stringList.AsEnumerable().Distinct().ToArray());
            string[] distinctItems2 = { "AAA", "BBBB" };
            stringList = new List<String>() { "AAA", "BBBB", "bbbb" };
            CollectionAssert.AreEqual(distinctItems2, stringList.AsEnumerable().Distinct(StringComparer.InvariantCultureIgnoreCase).ToArray());
        }

        [TestMethod]
        public void LastReturnsLastItem()
        {
            String lastItem = getStringList().Last();
            Assert.AreEqual("CCCC", lastItem);
            lastItem = getStringList().Last(s => s.Length == 3);
            Assert.AreEqual("AAA", lastItem);
            Assert.IsNull(getStringList().LastOrDefault(s => s.Length == 2));
        }

        [TestMethod]
        public void DefaultIfEmptyDefaultsEmptyList()
        {
            List<String> stringList = new List<String>();
            Assert.AreEqual("Empty", stringList.DefaultIfEmpty("Empty").LastOrDefault());
            Assert.IsNull(stringList.DefaultIfEmpty("Empty").LastOrDefault(s => s.Length == 2));
        }

        [TestMethod]
        public void LongCountReturnsSize()
        {
            Assert.AreEqual(3, getStringList().LongCount());
            Assert.AreEqual(2, getStringList().LongCount(s => s.Length == 4));
            Assert.AreEqual(0, getStringList().LongCount(s => s.Length == 2));
        }

        [TestMethod]
        public void MaxReturnsMaxItem()
        {
            List<int> intList = new List<int>() { 100, 400, 200 };
            Assert.AreEqual(400, intList.Max());
            Assert.AreEqual(800, intList.Max(s => s * 2));
        }

        [TestMethod]
        public void MinReturnsMinItem()
        {
            List<int> intList = new List<int>() { 200, 400, 150 };
            Assert.AreEqual(150, intList.Min());
            Assert.AreEqual(300, intList.Min(s => s * 2));
        }

        [TestMethod]
        public void SequenceEqualComparesCorrectly()
        {
            List<int> intList = new List<int>() { 200, 400 };
            List<int> intList2 = new List<int>() { 200, 400 };
            Assert.IsTrue(intList.SequenceEqual(intList2));
            List<int> intList3 = new List<int>() { 400, 200 };
            Assert.IsFalse(intList.SequenceEqual(intList3));
            intList3.Reverse();
            Assert.IsTrue(intList.SequenceEqual(intList3));
        }

        [TestMethod]
        public void SequenceEqualComparesStringsCorrectly()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            List<String> stringList2 = new List<String>() { "ONE", "TWO", "THREE" };
            Assert.IsFalse(stringList.SequenceEqual(stringList2));
            Assert.IsTrue(stringList.SequenceEqual(stringList2, StringComparer.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void SingleReturnsOnlyItem()
        {
            List<String> stringList = new List<String>() { "One" };
            Assert.AreEqual("One", stringList.Single());
            stringList = new List<String>() { "One", "Two" };
            Assert.AreEqual("One", stringList.Single(s => s.Equals("One")));
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void SingleThrowsInvalidOperationExceptionOnMoreThanOneMatching()
        {
            List<String> stringList = new List<String>() { "One", "Two" };
            stringList.Single(s => s.Length == 3);
        }

        [TestMethod]
        public void SkipBypassesElements()
        {
            List<String> stringList = new List<String>() { "One", "Two" };
            Assert.AreEqual("Two", stringList.Skip(1).Single(s => s.Length == 3));
            Assert.AreEqual("Two", Enumerable.Skip(stringList, 1).Single(s => s.Length == 3));
        }

        [TestMethod]
        public void SkipWhileBypassesMatchinElements()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            Assert.AreEqual("Three", stringList.SkipWhile(s => s.Length == 3).Single());
        }

        [TestMethod]
        public void SumReturnsTotalLengthOfStringsInList()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            Assert.AreEqual(11, stringList.Sum(s => s.Length));
            Assert.AreEqual(11, Enumerable.Sum(stringList, s => s.Length));
        }

        [TestMethod]
        public void TakePullsTheNumberSpecifiedOffEnumerable()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            Assert.AreEqual("One", stringList.Take(1).Single());
        }

        [TestMethod]
        public void TakeWhileStopsAfterStringNotLength3()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            IEnumerable<String> valueEnumerator = stringList.TakeWhile(s => s.Length == 3);
            List<String> expectedStrings = new List<String>() { "One", "Two" };
            CollectionAssert.AreEqual(expectedStrings, valueEnumerator.ToList());
        }

        [TestMethod]
        public void ThenByOrdersStringsAlphabetically()
        {
            List<String> stringList = new List<String>() { "Three", "Two", "One", "Four" };
            List<String> sortedList = stringList.OrderBy(s => s.Length).ThenBy(s => s).ToList();
            List<String> expectedStrings = new List<String>() { "One", "Two", "Four", "Three" };
            CollectionAssert.AreEqual(expectedStrings, sortedList);
        }

        [TestMethod]
        public void OrderByDescendingOrdersStringsByLength()
        {
            List<String> stringList = new List<String>() { "Three", "Two", "One", "Four", "Five" };
            List<String> sortedList = stringList.OrderByDescending(s => s.Length).ThenByDescending(s => s).ToList();
            List<String> expectedStrings = new List<String>() { "Three",  "Four", "Five", "Two", "One" };
            CollectionAssert.AreEqual(expectedStrings, sortedList);
        }

        [TestMethod]
        public void ThenByDescendingOrdersStringsReverseAlphabetically()
        {
            List<String> stringList = new List<String>() { "Three", "Two", "One", "Four", "Five" };
            List<String> sortedList = stringList.OrderBy(s => s.Length).ThenByDescending(s => s).ToList();
            List<String> expectedStrings = new List<String>() { "Two", "One", "Four", "Five", "Three" };
            CollectionAssert.AreEqual(expectedStrings, sortedList);
        }

        [TestMethod]
        public void RepeatRepeatsItemSpecified()
        {
            List<String> repeatedList = Enumerable.Repeat("One", 3).ToList();
            List<String> expectedStrings = new List<String>() { "One", "One", "One" };
            CollectionAssert.AreEqual(expectedStrings, repeatedList);
        }

        [TestMethod]
        public void AggregateAggregatesAcrossItems()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            String combinedString = stringList.Aggregate((fullString, nextString) => fullString + " " + nextString);
            Assert.AreEqual("One Two Three Four Five", combinedString);
            int totalLength = stringList.Aggregate(0, (lengthTotal, nextString) => lengthTotal += nextString.Length);
            Assert.AreEqual(19, totalLength);
            String actualLongestString = stringList.Aggregate("", (longestString, nextString) => nextString.Length > longestString.Length ? nextString : longestString);
            Assert.AreEqual("Three", actualLongestString);
        }

        [TestMethod]
        public void ContainsReturnsIfStringListHasStringStartingWithT()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            Assert.IsTrue(stringList.Contains("One"));
            StringStartsWithComparer startsWithComparer = new StringStartsWithComparer();
            Assert.IsTrue(stringList.Contains("O", startsWithComparer));
        }

        class StringStartsWithComparer : IEqualityComparer<String> {
            public bool Equals(String first, String second)
            {
                return first.StartsWith(second);
            }

            public int GetHashCode(String first)
            {
                return first.GetHashCode();
            }
        }

        [TestMethod]
        public void WhereReturnsCorrectItems()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            var stringsWithT = from strings in stringList where strings.Contains("T") orderby strings select strings;
            List<String> expectedStrings = new List<String>() { "Three", "Two" };
            CollectionAssert.AreEqual(expectedStrings, stringsWithT.ToList());
            List<String> stringsWithT2 = stringList.Where(str => str.Contains("T")).ToList();
            CollectionAssert.AreEquivalent(expectedStrings, stringsWithT2.ToList());
        }

        [TestMethod]
        public void GroupByGroupsStringsArrayByCountOfStrings()
        {
            List<String> stringList = new List<String>() { "One", "Two", "One", "Three", "Two" };
            Dictionary<String, int> countOfStringsDictionary = stringList.GroupBy(theString => theString)
                .ToDictionary(x => x.Key, x => x.Count());

            Dictionary<String, int> expectedDictionary = new Dictionary<String, int> () {
                { "One", 2}, { "Two", 2}, { "Three", 1}
            };
            CollectionAssert.AreEquivalent(expectedDictionary, countOfStringsDictionary);
        }

        [TestMethod]
        public void GroupByGroupsStringsArrayByCountOfStringsUsingResultSelector()
        {
            List<String> stringList = new List<String>() { "One", "Two", "One", "Three", "Two" };
            Dictionary<String, int> countOfStringsDictionary = stringList.GroupBy(
                theString => theString,
                (theKey, theStringGrouping) => new {
                    OriginalKeyString = theKey,
                    CountOfStrings = theStringGrouping.Count()
                })
                .ToDictionary(x => x.OriginalKeyString, x => x.CountOfStrings);

            Dictionary<String, int> expectedDictionary = new Dictionary<String, int>() {
                { "One", 2}, { "Two", 2}, { "Three", 1}
            };
            CollectionAssert.AreEquivalent(expectedDictionary, countOfStringsDictionary);
        }

        [TestMethod]
        public void OfTypeFiltersOutNonStrings()
        {
            ArrayList myList = new ArrayList() { "One", 2, "Three", 4 };
            List<String> stringList = myList.OfType<String>().ToList();
            List<String> expectedStringList = new List<String>() { "One", "Three" };
            CollectionAssert.AreEquivalent(expectedStringList, stringList);
        }

        [TestMethod]
        public void ToLookupTransformsStringListIntoLookupIndexedByFirstCharacter()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three", "Four" };
            ILookup<char, string> stringsByCharLookup = stringList.ToLookup(str => Convert.ToChar(str.Substring(0, 1)),
                p => p);
            List<String> oList = new List<String>() { "One" };
            CollectionAssert.AreEqual(oList, stringsByCharLookup['O'].ToList());
            List<String> tList = new List<String>() { "Two", "Three" };
            CollectionAssert.AreEqual(tList, stringsByCharLookup['T'].ToList());
            List<String> fList = new List<String>() { "Four" };
            CollectionAssert.AreEqual(fList, stringsByCharLookup['F'].ToList());
        }

        [TestMethod]
        public void ProjectionExampleReturningStringsAndLengthsFromLINQStatement()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three", "Four" };
            var stringsWithLengths = from str in stringList select new { Value = str, Length = str.Length };
            List<dynamic> expectedDataList = new List<dynamic>() {
                { new { Value = "One", Length = 3} }, 
                { new { Value = "Two", Length = 3} }, 
                { new { Value = "Three", Length = 5} },
                { new { Value = "Four", Length = 4} }
            };
            dynamic dynExample = new { Ex = "hello", Size = 12 };
            CollectionAssert.AreEquivalent(expectedDataList, stringsWithLengths.ToList());
        }

        [TestMethod]
        public void UnionReturnsUniqueCombinationOfElements()
        {
            List<String> stringList = new List<String>() { "One", "Three", "Four" };
            List<String> stringList2 = new List<String>() { "One", "Two", "Three" };
            List<String> unionStringList = stringList.Union(stringList2).ToList();
            List<String> expectedList = new List<String>() { "One", "Two", "Three", "Four" };
            CollectionAssert.AreEquivalent(expectedList, unionStringList);
        }

        [TestMethod]
        public void UnionReturnsUniqueCombinationOfStringElementsCaseInsensitive()
        {
            List<String> stringList = new List<String>() { "One" };
            List<String> stringList2 = new List<String>() { "ONE" };
            List<String> unionStringList = stringList.Union(stringList2).ToList();
            List<String> expectedList = new List<String>() { "One", "ONE" };
            CollectionAssert.AreEquivalent(expectedList, unionStringList);
        }

        [TestMethod]
        public void ConcatReturnsBothSetsOfValues()
        {
            List<String> stringList = new List<String>() { "One", "Two" };
            List<String> stringList2 = new List<String>() { "One", "Two", "Three" };
            List<String> concatStringList = stringList.Concat(stringList2).ToList();
            List<String> expectedList = new List<String>() { "One", "Two", "One", "Two", "Three" };
            CollectionAssert.AreEquivalent(expectedList, concatStringList);
        }

    }
}
