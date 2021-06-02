using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_05
{
    public static class ValidTests
    {
        public static bool ContainsVowel(string testString)
        {
            var vowelCount = 0;
            char[] vowels = "aeiou".ToCharArray();

            foreach (char vowel in vowels)
            {
                vowelCount += testString.Count(f => (f == vowel));
            }

            if (vowelCount >= 3) return true;
            return false;
        }

        public static bool ContainsDoubleLetter(string testString)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            foreach (char letter in alphabet)
            {
                var doubleLetter = letter.ToString() + letter.ToString();
                if (testString.Contains(doubleLetter)) return true;
            }
            return false;
        }

        public static bool ContainsDisallowedLetterSet(string testString)
        {
            string[] disallowedLetterSet = new string[] { "ab", "cd", "pq", "xy" };

            foreach (string letterSet in disallowedLetterSet)
            {
                if (testString.Contains(letterSet)) return true;
            }
            return false;
        }

        public static bool ContainsDuplicateDoubles(string testString)
        {
            var doublesSet = new List<string>();

            // get list of strings to test
            for (int index = 0; index < testString.Length - 1; index++)
            {
                doublesSet.Add(testString.Substring(index, 2));
            }

            // test for overlapping duplicates
            for (int index = 0; index < doublesSet.Count - 1; index++) 
            {
                if (doublesSet[index] == doublesSet[index + 1]) return false;
            }


            //test each string in list against substrings of test string
            for(int index1 = 0; index1 < testString.Length - 2; index1++)
            {
                var testSection1 = testString.Substring(index1, 2);
                for (int index2 = index1+2; index2 < testString.Length - 1; index2++)
                {
                    var testSection2 = testString.Substring(index2, 2);
                    if (testSection1 == testSection2) return true;
                }
            }
            return false;
        }

        public static bool ContainsRepeatedSeperatedLetter(string testString)
        {
            char[] letters = testString.ToCharArray();

            for (int index = 0; index < letters.Length - 2; index++)
            {
                //Console.WriteLine($"{testString} : {index}-{letters[index]} : {index+2}-{letters[index+2]}");
                if (letters[index] == letters[index + 2]) return true;
            }
            //Console.ReadLine();
            return false;
        }
    }
}
