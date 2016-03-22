using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class NumberPrinter
    {
        public String GetNumbersUsingWhere(String stringToAnalyze)
        {
            stringToAnalyze = stringToAnalyze ?? String.Empty;
            IEnumerable<char> onlyNumberCharacters = stringToAnalyze.Where(x => Char.IsDigit(x));
            return String.Concat(onlyNumberCharacters);
        }

        public String GetNumbersUsingForEachLoop(String stringToAnalyze)
        {
            stringToAnalyze = stringToAnalyze ?? String.Empty;
            StringBuilder resultStringBuilder = new StringBuilder();
            foreach (char charToAnalyze in stringToAnalyze) 
            {
                if (Char.IsDigit(charToAnalyze)) 
                {
                    resultStringBuilder.Append(charToAnalyze);
                }
            }
            return resultStringBuilder.ToString();
        }

        public String GetNumbersUsingForLoop(String stringToAnalyze)
        {
            stringToAnalyze = stringToAnalyze ?? String.Empty;
            StringBuilder resultStringBuilder = new StringBuilder();
            for (int i = 0; i < stringToAnalyze.Length; i++)
            {
                char charToAnalyze = stringToAnalyze[i];
                if (Char.IsDigit(charToAnalyze))
                {
                    resultStringBuilder.Append(charToAnalyze);
                }
            }
            return resultStringBuilder.ToString();

        }

        public String GetNumbersUsingLinq(String stringToAnalyze)
        {
            stringToAnalyze = stringToAnalyze ?? String.Empty;
            IEnumerable<char> stringQuery = from characterToAnalyze in stringToAnalyze
                where Char.IsDigit(characterToAnalyze)
                select characterToAnalyze;
            return String.Concat(stringQuery);
        }

        public int CountWordsInString(String wordToFind, String stringToSearch)
        {
            stringToSearch = stringToSearch ?? String.Empty;
            string[] sourceWords = stringToSearch.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var matchQuery = from word in sourceWords
                             where word.ToLowerInvariant() == wordToFind.ToLowerInvariant()
                             select word;
            return matchQuery.Count();
        }

        public String SortWordsAlphabetically(String stringToSearch)
        {
            stringToSearch = stringToSearch ?? String.Empty;
            string[] sourceWords = stringToSearch.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var sortQuery = from word in sourceWords
                            orderby word
                            select word;
            return String.Join(" ", sortQuery);
        }

        public Boolean SentanceContainsWords(String stringToSearchThrough, string[] wordsToMatch)
        {
            stringToSearchThrough = stringToSearchThrough ?? String.Empty;
            string[] sentences = stringToSearchThrough.Split(new char[] { '.', '?', '!' });
            IEnumerable<String> sentanceQuery = from sentence in sentences
                                let w = sentence.Split(new char[] { ' ' },
                                                        StringSplitOptions.RemoveEmptyEntries)
                                where w.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count()
                                select sentence;
            return sentanceQuery.Any();
        }
    }
}
