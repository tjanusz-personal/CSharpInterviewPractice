using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPracticeTest
{
    class PowerOfTwo
    {
        public static ulong LARGEST_ULONG_POWER = 9223372036854775808UL;

        public bool IsPowerOfTwoUsingDecimal(ulong numberToCheck)
        {
            if (numberToCheck == 0)
            {
                return false;
            }

            ulong raisedValue = 0;
            int counterToRaiseToPowerOfTwo = 1;
            // TODO: fix me using a quicker way instead of looping through every potential value
            while (counterToRaiseToPowerOfTwo > 0 && raisedValue < LARGEST_ULONG_POWER)
            {
                raisedValue = Convert.ToUInt64(Math.Pow(2, counterToRaiseToPowerOfTwo));
                
                if (raisedValue == numberToCheck)
                {
                    return true;
                }
                if (raisedValue > numberToCheck)
                {
                    return false;
                }
                counterToRaiseToPowerOfTwo++;
            }
            return false;
        }

        internal bool IsPowerOfTwoUsingBinary(ulong numberToCheck)
        {
            // An arguably more direct way to check if an integer is a power of two is to access its binary representation. 
            // An unsigned integer is a power of two if and only if it has exactly one 1 bit. 
            // http://www.exploringbinary.com/ten-ways-to-check-if-an-integer-is-a-power-of-two-in-c/
            if (numberToCheck == 0)
            {
                return false;
            }
            return (numberToCheck & (numberToCheck - 1)) == 0;
        }
    }
}
