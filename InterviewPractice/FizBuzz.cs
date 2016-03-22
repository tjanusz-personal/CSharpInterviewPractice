using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class FizBuzz
    {
        public String GetStringValue(int aValue)
        {
            if (aValue == 0)
            {
                return aValue.ToString();
            }

            if ((aValue % 3 == 0) && (aValue % 5 == 0))
            {
                return "FizzBuzz";
            }
            if (aValue % 3 == 0)
            {
                return "Fizz";
            }

            if (aValue % 5 == 0)
            {
                return "Buzz";
            }

            return aValue.ToString();
        }

        public void printFizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(this.GetStringValue(i));
            }
        }
    }
}
