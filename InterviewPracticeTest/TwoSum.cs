using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPracticeTest
{
    class TwoSum
    {
        public Tuple<int, int> FindTwoSum(List<int> valuesToSum, int total)
        {
            if (!valuesToSum.Any())
            {
                return null;
            }
            // loop through each item one by one
            for (int iCount = 0; iCount < valuesToSum.Count; iCount++)
            {
                int startValue = valuesToSum.ElementAt(iCount);
                // loop second (this can probably be done with one pass
                for (int innerLoop = iCount; innerLoop < valuesToSum.Count; innerLoop++)
                {
                    int nextValue = valuesToSum.ElementAt(innerLoop);
                    if ((startValue + nextValue) == total)
                    {
                        return new Tuple<int, int>(startValue, nextValue);
                    }
                }
            }
            return null;
        }

        public Tuple<int, int> FindTwoSumGreedy(List<int> valuesToSum, int total)
        {
            if (!valuesToSum.Any())
            {
                return null;
            }
            int iCount = 0;
            foreach (int value in valuesToSum)
            {
                // search remaining elements by skipping past current position and 
                // find first match where (number added is total)
                int matchValue = valuesToSum.Skip(++iCount).FirstOrDefault(number => number + value == total);
                if (matchValue != 0)
                {
                    return new Tuple<int, int>(value, matchValue);
                }
            }
            return null;
        }

    }
}
