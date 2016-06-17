using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class InterviewTestQuestions
    {
        public static String location;
        public static DateTime time;

        public static String result;

        public int SumOfEvenArray(int[] arrayOfInts)
        {
            if (arrayOfInts == null || arrayOfInts.Length <= 0)
            {
                return 0;
            }
            return arrayOfInts.Where(x => x % 2 == 0).Sum();
        }

        public static async Task<String> SaySomething()
        {
            await Task.Delay(5);    // code immediately returns
            result = "hello world";
            return "Something";
        }

        public static void DoStuff()
        {
            SaySomething();
            Console.WriteLine(result);
        }
    }
}
